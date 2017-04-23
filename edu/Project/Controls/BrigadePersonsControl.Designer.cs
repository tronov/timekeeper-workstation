using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Project.Controls
{
    partial class BrigadePersonsControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbOperations.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Size = new Size(350, 46);
            // 
            // gbOperations
            // 
            this.gbOperations.Size = new Size(350, 50);
            // 
            // scMain
            // 
            this.scMain.Size = new Size(350, 200);
            this.scMain.SplitterDistance = 146;
            // 
            // gbItems
            // 
            this.gbItems.Size = new Size(350, 96);
            // 
            // BrigadePersonsControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.MinimumSize = new Size(350, 200);
            this.Name = "BrigadePersonsControl";
            this.Size = new Size(350, 200);
            this.gbOperations.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
