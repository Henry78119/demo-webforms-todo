using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoWebForms
{
    public partial class Default : Page
    {
        private List<TodoItem> Tasks
        {
            get
            {
                if (Session["Tasks"] == null)
                    Session["Tasks"] = new List<TodoItem>();
                return (List<TodoItem>)Session["Tasks"];
            }
            set
            {
                Session["Tasks"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                Tasks.Add(new TodoItem { TaskDescription = txtNewTask.Text });
                txtNewTask.Text = string.Empty;
                BindGrid();
            }
        }

        protected void gvTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteTask")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Tasks.RemoveAt(index);
                BindGrid();
            }
        }

        private void BindGrid()
        {
            gvTasks.DataSource = Tasks;
            gvTasks.DataBind();
        }
    }

    public class TodoItem
    {
        public string TaskDescription { get; set; }
    }
}