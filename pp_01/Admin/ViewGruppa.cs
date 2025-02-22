using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace pp_01.Admin
{
    public class ViewGruppa : Notify
    {
        public ObservableCollection<Trener> _ListTrener;
        public ObservableCollection<Gruppa> _ListGruppa;
        public ObservableCollection<Obuchau> _ListObuch;
        public ObservableCollection<Raspicanie> _ListRaspicanie;
        public ObservableCollection<Gruppa> ListGruppa
        {
            get => _ListGruppa ?? (_ListGruppa = new ObservableCollection<Gruppa>());
            set
            {
                _ListGruppa = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Trener> ListTrener
        {
            get => _ListTrener ?? (_ListTrener = new ObservableCollection<Trener>());
            set
            {
                _ListTrener = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Obuchau> ListObuch
        {
            get => _ListObuch ?? (_ListObuch = new ObservableCollection<Obuchau>());
            set
            {
                _ListObuch = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Raspicanie> ListRaspicanie
        {
            get => _ListRaspicanie ?? (_ListRaspicanie = new ObservableCollection<Raspicanie>());
            set
            {
                _ListRaspicanie = value;
                OnPropertyChanged();
            }
        }
      

        public ICommand
            _command_load_menu,
            _command_show_trener,
            _command_hide_trener,
            _command_load_trener,
             _command_show_obuch,
            _command_hide_obuch,
            _command_load_obuch,
            _command_show_rasp,
            _command_hide_rasp,
            _command_load_rasp,
            _command_show_arhiv,
            _command_show_addgruppa,
            _command_hide_addgruppa,
            _command_show_editgruppa,
            _command_hide_editgruppa,
            _commandSaveEdit,
            _command_show_edittrener,
            _command_hide_edittrener,
            _commandSaveEditTrener,
            _command_show_editrasp,
            _command_hide_editrasp,
            _commandSaveEditRasp,
            _commandSaveAddTrener,
             _command_show_addobuch,
            _command_hide_addobuch,
            _command_show_addtrener,
            _command_hide_addtrener,
            _command_addgruppa,
            save_gruppa,
          /*удаление*/
          _command_delete_trener,
            _command_delete_obuch,
            _command_delete_gruppa,
            _command_delete_rasp;

        private Visibility
            _visisibility_show_trener = Visibility.Collapsed,
            _visibility_show_obuch = Visibility.Collapsed,
            _visibility_show_rasp = Visibility.Collapsed,
            visibiity_show_editgruppa = Visibility.Collapsed,
             visibiity_show_edittrener = Visibility.Collapsed,
            visibility_show_editrasp = Visibility.Collapsed,
            visibility_show_addgruppa = Visibility.Collapsed,
            visibility_show_addobuch = Visibility.Collapsed,
            visibility_show_addtrener = Visibility.Collapsed;

        private Gruppa
           _editGruppa, _selectedtrener, saveaddgruppa;


        private Trener
            _editTrener, _addtrener;
        private Raspicanie
            _editRasp;

        public ICommand CommandLoad => _command_load_menu ?? (_command_load_menu = new MyCommand(Load));
        public ICommand CommandLoadTrener => _command_load_trener ?? (_command_load_trener = new MyCommand(LoadTrener));
        public ICommand CommandShowTrener => _command_show_trener ?? (_command_show_trener = new MyCommand(ShowTrener));
        public ICommand CommandHideTrener => _command_hide_trener ?? (_command_hide_trener = new MyCommand(HideTrener));
        public ICommand CommandLoadObuch => _command_load_obuch ?? (_command_load_obuch = new MyCommand(LoadObuch));
        public ICommand CommandShowObuch => _command_show_obuch ?? (_command_show_obuch = new MyCommand(ShowObuch));
        public ICommand CommandHideObuch => _command_hide_obuch ?? (_command_hide_obuch = new MyCommand(HideObuch));
        public ICommand CommandLoadRasp => _command_load_rasp ?? (_command_load_rasp = new MyCommand(LoadRasp));
        public ICommand CommandShowRasp => _command_show_rasp ?? (_command_show_rasp = new MyCommand(ShowRasp));
        public ICommand CommandHideRasp => _command_hide_rasp ?? (_command_hide_rasp = new MyCommand(HideRasp));
        public ICommand CommandShowEditGruppa => _command_show_editgruppa ?? (_command_show_editgruppa = new MyCommand(ShowEditGruppa));
        public ICommand CommandHideEditGruppa => _command_hide_editgruppa ?? (_command_hide_editgruppa = new MyCommand(HideEditGruppa));
        public ICommand CommandSaveEdit => _commandSaveEdit ?? (_commandSaveEdit = new MyCommand(SaveEdit));
        public ICommand CommandShowEditTrener => _command_show_edittrener ?? (_command_show_edittrener = new MyCommand(ShowEditTrener));
        public ICommand CommandHideEditTrener => _command_hide_edittrener ?? (_command_hide_edittrener = new MyCommand(HideEditTrener));
        public ICommand CommandSaveEditTreter => _commandSaveEditTrener ?? (_commandSaveEdit = new MyCommand(SaveEditTrener));
        public ICommand CommandShowEditRasp => _command_show_editrasp ?? (_command_show_editrasp = new MyCommand(ShowEditRasp));
        public ICommand CommandHideEditRasp => _command_hide_editrasp ?? (_command_hide_editrasp = new MyCommand(HideEditRasp));
        public ICommand CommandSaveEditRasp => _commandSaveEditRasp ?? (_commandSaveEditRasp = new MyCommand(SaveEditRasp));
        public ICommand CommandShowAddGruppa => _command_show_addgruppa ?? (_command_show_addgruppa = new MyCommand(ShowAddGruppa));
        public ICommand CommandHideAddGruppa => _command_hide_addgruppa ?? (_command_hide_addgruppa = new MyCommand(HideAddGruppa));
        public ICommand CommandShowAddObuch => _command_show_addobuch ?? (_command_show_addobuch = new MyCommand(ShowAddObuch));
        public ICommand CommandHideAddObuch => _command_hide_addobuch ?? (_command_hide_addobuch = new MyCommand(HideAddObuch));
        public ICommand CommandShowAddTrener => _command_show_addtrener ?? (_command_show_addtrener = new MyCommand(ShowAddTrener));
        public ICommand CommandHideAddTrener => _command_hide_addtrener ?? (_command_hide_addtrener = new MyCommand(HideAddTrener));
        public ICommand CommandSaveGruppa => save_gruppa ?? (save_gruppa = new MyCommand(SaveGruppa));
        public ICommand CommandSaveAddTrener => _commandSaveAddTrener ?? (_commandSaveAddTrener = new MyCommand(SaveAddTrener));

        /*удаление*/
        public ICommand CommandDeleteTrener => _command_delete_trener ?? (_command_delete_trener = new MyCommand(DeleteTrenera));
        public ICommand CommandDeleteObuch => _command_delete_obuch ?? (_command_delete_obuch = new MyCommand(DeleteObuch));
        public ICommand CommandDeleteGruppa => _command_delete_gruppa ?? (_command_delete_gruppa = new MyCommand(DeleteGruppa));
        public ICommand CommandDeleteRasp => _command_delete_rasp ?? (_command_delete_rasp = new MyCommand(DeleteRasp));

       
        [Test(ExpectedResult = true)]
        public bool Load()
        {
            try
            {
                ListGruppa.Clear();
                foreach (Gruppa gr in Connection.DB.Gruppa.ToList())
                {
                    ListGruppa.Add(gr);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void LoadTrener()
        {
            ListTrener.Clear();
            foreach (Trener tr in Connection.DB.Trener.ToList())
            {
                ListTrener.Add(tr);
            }

        }
        private void LoadObuch()
        {
            ListObuch.Clear();
            foreach (Obuchau ob in Connection.DB.Obuchau.ToList())
            {
                ListObuch.Add(ob);
            }
        }
        private void LoadRasp()
        {
            ListRaspicanie.Clear();
            foreach (Raspicanie r in Connection.DB.Raspicanie.ToList())
            {
                ListRaspicanie.Add(r);
            }
        }
            public ViewGruppa()
        {
            Load();
            LoadTrener();
            LoadObuch();
            LoadRasp();
            }

        public Visibility visibilityShowTrener
        {
            get => _visibility_show_rasp;
            set
            {
                _visibility_show_rasp = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowObuch
        {
            get => _visibility_show_obuch;
            set
            {
                _visibility_show_obuch = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowRasp
        {
            get => _visibility_show_obuch;
            set
            {
                _visibility_show_obuch = value;
                OnPropertyChanged();
            }
        }
          public Visibility visibilityShowEditGruppa
        {
            get => visibiity_show_editgruppa;
            set
            {
                visibiity_show_editgruppa = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowEditTrener
        {
            get => visibiity_show_edittrener;
            set
            {
                visibiity_show_edittrener = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowEditRasp
        {
            get => visibility_show_editrasp;
            set
            {
                visibility_show_editrasp = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowAddGruppa
        {
            get => visibility_show_addgruppa;
            set
            {
                visibility_show_addgruppa = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowAddObuch
        {
            get => visibility_show_addobuch;
            set
            {
                visibility_show_addobuch = value;
                OnPropertyChanged();
            }
        }
        public Visibility visibilityShowAddTrener
        {
            get => visibility_show_addtrener;
            set
            {
                visibility_show_addtrener = value;
                OnPropertyChanged();
            }
        }
        public Gruppa EditGruppa
        {
            get => _editGruppa;
            set
            {
                _editGruppa = value;
                OnPropertyChanged();
            }
        }

        public Trener AddTrener
        {
            get => _addtrener;
            set
            {
                _addtrener = value;
                OnPropertyChanged();
            }
        }
        public Gruppa SaveAddGruppa
        {
            get => saveaddgruppa;
            set
            {
                saveaddgruppa = value;
                OnPropertyChanged();
            }
        }

        public Gruppa SelectedTrener
        {
            get => _selectedtrener;
            set
            {
                _selectedtrener = value;
                OnPropertyChanged();
            }
        }
        public Trener EditTrener
        {
            get => _editTrener;
            set
            {
                _editTrener = value;
                OnPropertyChanged();
            }
        }
        public Raspicanie EditRasp
        {
            get => _editRasp;
            set
            {
                _editRasp = value;
                OnPropertyChanged();
            }
        }

        private void ShowTrener()
        {
            visibilityShowTrener = Visibility.Visible;
        }

        private void HideTrener()
        {
            visibilityShowTrener = Visibility.Collapsed;
        }
        private void ShowObuch()
        {
            visibilityShowObuch = Visibility.Visible;
        }

        private void HideObuch()
        {
            visibilityShowObuch = Visibility.Collapsed;
        }
        private void ShowRasp()
        {
            visibilityShowRasp = Visibility.Visible;
        }

        private void HideRasp()
        {
            visibilityShowRasp = Visibility.Collapsed;
        }
    
        private void ShowEditGruppa(object item)
        {
            Gruppa
                gruppa = item as Gruppa;

            EditGruppa = new Gruppa()
            {
                id_gruppa = gruppa.id_gruppa,
                name_gruppa = gruppa.name_gruppa,
                svedeniy = gruppa.svedeniy,
                id_trener = gruppa.id_trener,
            };
            visibilityShowEditGruppa = Visibility.Visible;
        }
        private void SaveEdit()
        {
            Gruppa gruppa = Connection.DB.Gruppa.FirstOrDefault(a => a.id_gruppa == EditGruppa.id_gruppa);
            gruppa.name_gruppa = EditGruppa.name_gruppa;
            gruppa.svedeniy = EditGruppa.svedeniy;
            gruppa.id_trener = EditGruppa.id_trener;
            Connection.DB.SaveChanges();
            visibilityShowEditGruppa = Visibility.Collapsed;
            Load();
            LoadTrener();
            LoadObuch();
            LoadRasp();
         
        }
        private void SaveAddTrener()
        {
            Trener trener = Connection.DB.Trener.FirstOrDefault(a => a.id_trener == AddTrener.id_trener);
            trener.fio = AddTrener.fio;
            trener.dolzhnoct = AddTrener.dolzhnoct;
            Connection.DB.SaveChanges();
            Load();
            LoadTrener();
        }
        private void HideEditGruppa()
        {
            visibilityShowEditGruppa = Visibility.Collapsed;
        }

        private void ShowEditTrener(object item)
        {
            Trener
                trener = item as Trener;
            EditTrener = new Trener()
            {
                id_trener = trener.id_trener,
                fio = trener.fio,
                dolzhnoct = trener.dolzhnoct,

            };
            visibilityShowEditTrener = Visibility.Visible;
        }
        private void SaveEditTrener()
        {
            Trener trener = Connection.DB.Trener.FirstOrDefault(s => s.id_trener == EditTrener.id_trener);
            trener.fio = EditTrener.fio;
            trener.dolzhnoct = EditTrener.dolzhnoct;
            Connection.DB.SaveChanges();
            visibilityShowEditTrener = Visibility.Collapsed;
            Load();
            LoadTrener();
            LoadObuch();
            LoadRasp();
         
        }
        private void HideEditTrener()
        {
            visibilityShowEditTrener = Visibility.Collapsed;
        }

        private void ShowEditRasp(object item)
        {
            Raspicanie
                raspicanie = item as Raspicanie;
            EditRasp = new Raspicanie()
            {
                id_trener = raspicanie.id_trener,
                id_gruppa = raspicanie.id_gruppa,
                data_z = raspicanie.data_z,
                time_z = raspicanie.time_z,

            };
            visibilityShowEditRasp = Visibility.Visible;
        }
        private void SaveEditRasp()
        {
            Raspicanie raspicanie = Connection.DB.Raspicanie.FirstOrDefault(s => s.id_trener == EditRasp.id_trener);

            raspicanie.id_gruppa = EditRasp.id_gruppa;
            raspicanie.id_trener = EditRasp.id_trener;
            raspicanie.data_z = EditRasp.data_z;
            raspicanie.time_z = EditRasp.time_z;

            Connection.DB.SaveChanges();
            visibilityShowEditRasp = Visibility.Collapsed;
            Load();
            LoadTrener();
            LoadObuch();
            LoadRasp();
       

        }
        private void HideEditRasp()
        {
            visibilityShowEditRasp = Visibility.Collapsed;
        }

        private void ShowAddGruppa()
        {
            visibilityShowAddGruppa = Visibility.Visible;
        }

        private void HideAddGruppa()
        {
            visibilityShowAddGruppa = Visibility.Collapsed;
        }
        private void ShowAddObuch()
        {
            visibilityShowAddObuch = Visibility.Visible;
        }

        private void HideAddObuch()
        {
            visibilityShowAddObuch = Visibility.Collapsed;
        }
        private void ShowAddTrener()
        {
            visibilityShowAddTrener = Visibility.Visible;
        }

        private void HideAddTrener()
        {
            visibilityShowAddTrener = Visibility.Collapsed;
        }

        private void SaveGruppa()
        {
            Gruppa gruppa = Connection.DB.Gruppa.FirstOrDefault(a => a.id_gruppa == SaveAddGruppa.id_gruppa);
            gruppa.name_gruppa = SaveAddGruppa.name_gruppa;
            gruppa.svedeniy = SaveAddGruppa.svedeniy;
            gruppa.id_trener = SelectedTrener.id_trener;
            Connection.DB.SaveChanges();
            visibilityShowAddGruppa = Visibility.Collapsed;
            Load();
            LoadTrener();
            LoadObuch();
            LoadRasp();
       
        }
        private bool CanDeleteTrener(Trener trener)
        {
            return !Connection.DB.Gruppa.Any(g => g.id_trener == trener.id_trener);
        }

        private void DeleteTrenera(object item)
        {
            Trener trener = item as Trener;
            if (trener != null)
            {
                if (CanDeleteTrener(trener))
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить этого тренера?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            Connection.DB.Trener.Remove(trener);
                            Connection.DB.SaveChanges();
                            ListTrener.Remove(trener);
                            MessageBox.Show("Тренер успешно удален.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка при удалении тренера: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    var groups = Connection.DB.Gruppa.Where(g => g.id_trener == trener.id_trener).Select(g => g.name_gruppa).ToList();
                    string groupNames = string.Join(", ", groups);
                    MessageBox.Show($"Невозможно удалить тренера, так как он привязан к следующим группам: {groupNames}. Пожалуйста, измените тренера в этих группах, прежде чем удалять.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DeleteObuch(object item)
        {
            Obuchau obuch = item as Obuchau;
            if (obuch != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этого обучающегося?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Connection.DB.Obuchau.Remove(obuch);
                        Connection.DB.SaveChanges();
                        ListObuch.Remove(obuch);
                        MessageBox.Show("Обучающийся успешно удален.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении обучающегося: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteGruppa(object item)
        {
            Gruppa gruppa = item as Gruppa;
            if (gruppa != null)
            {
                string message = "Вы уверены, что хотите удалить эту группу?\n" +
                                 "Это действие также удалит всех обучающихся в этой группе и связанное расписание.";
                if (MessageBox.Show(message, "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Удаление связанных обучающихся
                        var relatedObuchau = Connection.DB.Obuchau.Where(o => o.id_gruppa == gruppa.id_gruppa).ToList();
                        Connection.DB.Obuchau.RemoveRange(relatedObuchau);

                        // Удаление связанного расписания
                        var relatedRaspicanie = Connection.DB.Raspicanie.Where(r => r.id_gruppa == gruppa.id_gruppa).ToList();
                        Connection.DB.Raspicanie.RemoveRange(relatedRaspicanie);

                        // Удаление самой группы
                        Connection.DB.Gruppa.Remove(gruppa);
                        Connection.DB.SaveChanges();

                        // Обновление списков в UI
                        ListGruppa.Remove(gruppa);
                        foreach (var obuch in relatedObuchau)
                            ListObuch.Remove(obuch);
                        foreach (var rasp in relatedRaspicanie)
                            ListRaspicanie.Remove(rasp);

                        MessageBox.Show("Группа и связанные с ней данные успешно удалены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении группы: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteRasp(object item)
        {
            Raspicanie ras = item as Raspicanie;
            if (ras != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить это расписание?", "Подтверждение удаления", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        Connection.DB.Raspicanie.Remove(ras);
                        Connection.DB.SaveChanges();
                        ListRaspicanie.Remove(ras);
                        MessageBox.Show("Расписание успешно удалено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка при удалении расписания: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
   }    }
}

