using FilmFilter.Models;
using Filter.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ViewModel;

namespace FilmFilter
{
    public partial class MoviesPro : Form
    {
        Movies Items;
        IFilter[] loaders;
        IFilter[] tmpLoaders = new List<IFilter>().ToArray();
        List<CheckedListBox> listOfList = new List<CheckedListBox>();
        public delegate void InvokeDelegate();

        public MoviesPro()
        {
            InitializeComponent();
            Items = GetListFromXML();
            dataGridView.DataSource = Mapper.GenerateModelToView(Items.MovieList);

            System.Threading.Timer timer = new System.Threading.Timer(t =>
            {
                GetLoaders();
                foreach (IFilter loader in loaders.Where(x => tmpLoaders.All(tmp => tmp.Name != x.Name)))
                {
                    Label lbl = new Label();
                    lbl.Text = loader.Name;
                    CheckedListBox box = new CheckedListBox();
                    box.Name = loader.GetType().Name;
                    box.Width = 155;
                    var listFilters = loader.GetListFilter(Items.MovieList);
                    listFilters.ForEach(x => box.Items.Add(x));
                    box.ItemCheck += new ItemCheckEventHandler(ItemChack);
                    flowLayoutPanel1.BeginInvoke(new InvokeDelegate(() => { flowLayoutPanel1.Controls.Add(lbl); flowLayoutPanel1.Controls.Add(box); }));
                    listOfList.Add(box);
                }
                tmpLoaders = loaders;
            }, null, 0, 2 * 1000);

        }

        private void ItemChack(object sender, ItemCheckEventArgs args)
        {
            List<Movie> result = Items.MovieList.Select(x => x).ToList();
            foreach (IFilter loader in loaders)
            {
                foreach (CheckedListBox list in listOfList)
                {
                    if (list.Name == loader.GetType().Name)
                    {
                        List<string> listFilters = new List<string>();
                        string badItem = "";
                        foreach (var item in list.SelectedItems)
                        {
                            if (args.NewValue == CheckState.Checked)
                                listFilters.Add(item.ToString());
                            else
                            {
                                badItem = item.ToString();
                            }
                        }
                        foreach (var item in list.CheckedItems)
                        {
                            if (item.ToString() != badItem)
                                listFilters.Add(item.ToString());
                        }
                        if (listFilters.Count > 0)
                        {
                            List<Movie> listByFilter = loader.GetByFilter(Items.MovieList, listFilters);
                            result = result.Intersect(listByFilter).ToList();
                        }
                        list.ClearSelected();
                    }
                }
            }
            dataGridView.DataSource = Mapper.GenerateModelToView(result);
        }

        public void GetLoaders()
        {
            string extesionPath = Directory.GetCurrentDirectory().ToString() + "/../../../Extensions";
            var pluginFiles = Directory.GetFiles(extesionPath, "*.dll");

            loaders = (
                from file in pluginFiles
                let asm = Assembly.LoadFile(file)
                from type in asm.GetTypes()
                where typeof(IFilter).IsAssignableFrom(type)
                select (IFilter)Activator.CreateInstance(type)
                ).ToArray();
           }
        public Movies GetListFromXML()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "movies";
            xRoot.IsNullable = true;
            XmlSerializer serializer = new XmlSerializer(typeof(Movies), xRoot);

            using (FileStream stream = File.OpenRead("../../XML/movies.xml"))
            {
                Movies dezerializedList = (Movies)serializer.Deserialize(stream);
                return dezerializedList;
            }
        }
    }
}
