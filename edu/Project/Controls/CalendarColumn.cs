using System;
using System.Windows.Forms;

namespace Project.Controls
{

    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn()
         : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                 !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
        {
            Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
         initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
             dataGridViewCellStyle);
            CalendarEditingControl ctl =
             DataGridView.EditingControl as CalendarEditingControl;
        }

        public override Type EditType
        {
            get
            {
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }
    }

    internal class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dataGridView;
        private bool _valueChanged;

        public CalendarEditingControl()
        {
            Format = DateTimePickerFormat.Short;
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return Value.ToShortDateString();
            }
            set
            {
                if (value is string)
                {
                    Value = DateTime.Parse((string)value);
                }
            }
        }

        public object GetEditingControlFormattedValue(
         DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(
         DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex { get; set; }

        public bool EditingControlWantsInputKey(
         Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return false;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return _dataGridView; }
            set { _dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return _valueChanged; }
            set { _valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return Cursor; }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            _valueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}