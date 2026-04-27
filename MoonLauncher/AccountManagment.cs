using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Windows.Forms;
using static MoonLauncher.StaticRequests;

namespace MoonLauncher
{
    public partial class AccountManagment : Form
    {
        public LauncherSettings Settings { get; private set; }

        private int SettingsChangesCount = 0;       // Счетчик изменений

        public AccountManagment(LauncherSettings settings)
        {
            InitializeComponent();
            Settings = settings ?? new LauncherSettings();
        }

        private BindingList<string> TempNicknameStorage = new BindingList<string>();     // Временное хранилище профилей (Костыль. На производительность не вляет, оставляем)
        private List<string> SaveNicknameStorage = new List<string>();         // Временное хранилище созданных профилей
        private List<string> DeleteNicknameStorage = new List<string>();       // Временное хранилище удаленных профилей
                                                                                 

        private void SaveChanges()      // Сохранение профилей
        {
            if (DeleteNicknameStorage.Count > 0)                        // Если во временном хранилище есть данные к удалению, то работаем следующим путем:
            {                                                           // Берем из хранилища по одному нику и удаляем его из списка профилей
                foreach (string nick in DeleteNicknameStorage)          // В конце очищаем временное хранилище для предотвращения багов
                {
                    Settings.SavedNicknames.Remove(nick);                   
                }
                DeleteNicknameStorage.Clear();
            }

            if (SaveNicknameStorage.Count > 0)                          // Если во временном хранилище есть данные к созданию, то работаем следующим путем:
            {                                                           // Берем из хранилища по одному нику и добавляем его в список профилей
                foreach (string nick in SaveNicknameStorage)            // В конце очищаем временное хранилище для предотвращения багов
                {
                    Settings.SavedNicknames.Add(nick);
                }
                SaveNicknameStorage.Clear();
            }

            cmbNicknames.DataSource = Settings.SavedNicknames;          // Вбиваем в combobox обновленные данные профилей
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            cmbNicknames.DataSource = Settings.SavedNicknames;
            Settings.SavedNicknames.ToList().ForEach(TempNicknameStorage.Add);      // Передаем временному хранилищу изолированные данные из SavedNicknames 
        }

        private void btnSaveNickname_Click(object sender, EventArgs e)
        {
            string txtNickname = txtNewNickname.Text;

            if (string.IsNullOrWhiteSpace(txtNickname))                 // Проверяем строку на пустоту
            {
                MessageBox.Show("The nickname field must not be empty!");
                return;
            }

            txtNickname = txtNickname.Trim();               // Обрезаем пробелы в нике, если они есть

            if (!Settings.SavedNicknames.Contains(txtNickname) && !SaveNicknameStorage.Contains(txtNickname))         // Если список профилей НЕ содержит ник, который мы пытаемся создать, то:
            {                                                           // Добавляем его в список
                SaveNicknameStorage.Add(txtNickname);                   // Прибавляем единицу к счетчику изменений
                TempNicknameStorage.Add(txtNickname);
                cmbNicknames.DataSource = TempNicknameStorage;
                SettingsChangesCount++;
            }
            else
            {
                MessageBox.Show("This nickname already exists!");       // Если никнейм, который мы пытаемся создать, уже существует, то сообщаем об этом пользователю
                return;
            }
        }

        private void btnDeleteNickname_Click(object sender, EventArgs e)
        {
            DialogResult resultDeleteNickname = MessageBox.Show($"Are you sure you want to delete this account?", "Deleting a account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDeleteNickname == DialogResult.Yes)
            {
                string selectedNickname = cmbNicknames.Text;

                if (selectedNickname == defaultNickname)        // Если пользователь пытается удалить стандартный профиль, то говорим ему об этом
                {
                    MessageBox.Show("You cannot delete the standard user!");
                }
                else
                {
                    if (Settings.SavedNicknames.Contains(selectedNickname))         // Если список профилей содержит профиль, который мы удаляем, то:
                    {                                                               // Добавляем удаляемый профиль в список временного хранилища, подготовленного к удалению
                        DeleteNicknameStorage.Add(selectedNickname);                // Прибавляем единицу к счетчику изменений
                        TempNicknameStorage.Remove(selectedNickname);
                        cmbNicknames.DataSource = TempNicknameStorage;
                        SettingsChangesCount++;
                    }
                    else if (SaveNicknameStorage.Contains(selectedNickname))
                    {
                        SaveNicknameStorage.Remove(selectedNickname);
                        TempNicknameStorage.Remove(selectedNickname);
                        cmbNicknames.DataSource = TempNicknameStorage;
                        SettingsChangesCount--;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)      // Not in use
        {
            /*if (Settings is null)
                Settings = new LauncherSettings();*/

            DialogResult = DialogResult.OK;
            //Close();  Unnecessary?
        }

        private void btnCancel_Click(object sender, EventArgs e)    // Not in use
        {
            DialogResult = DialogResult.Cancel;
            //Close();  Unnecessary?
        }

        private void accmanagement_Close(object sender, FormClosingEventArgs e)         // Закрытие формы AccountManagement
        {
            if (SettingsChangesCount == 0)          // Если счетчик изменений равен нулю,
                return;                             // пропускаем дальнейшие действия

            DialogResult saveChanges = MessageBox.Show($"Save {SettingsChangesCount} changes?", "Saving changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (saveChanges == DialogResult.Yes)        // Спрашиваем у пользователя, согласен ли он применить {Количество} изменений?
            {
                SaveChanges();      // Вызываем сохранение профилей
                SettingsChangesCount = 0;       // Обнуляем счетчик изменений
                DialogResult = DialogResult.OK;     // Выходим из диалога со статусом OK
            }
            else
            {
                SettingsChangesCount = 0;       // Обнуляем счетчик изменений
                DeleteNicknameStorage.Clear();  
                SaveNicknameStorage.Clear();    //
            }                                   // Очищаем временные хранилища
        }                                       //
    }
}
