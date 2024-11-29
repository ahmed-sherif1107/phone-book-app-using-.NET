using Day07ADO.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07ADO.BL.PhoneBookV2
{
    public static class ContactBL
    {
        //function => Static => convert to Sql command
        public static DataTable GetByID(int _id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE ID = "+_id );
            return DALPhoneBook.Select(cmd);//On the Fly
            
        }

        public static DataTable GetAll()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees order by ID");
            return DALPhoneBook.Select(cmd);//On the Fly
        }

        public static int AddContact(int _id, string _name, string _phone, string _address)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employees values (@id, @name, @phone, @address)");
            cmd.Parameters.AddWithValue("@id", _id);
            cmd.Parameters.AddWithValue("@name", _name);
            cmd.Parameters.AddWithValue("@phone", _phone);
            cmd.Parameters.AddWithValue("@address", _address);
            return DALPhoneBook.DML(cmd);//On the Fly
        }

        public static int UpdateContact(int _id, string _name, string _phone, string _address)
        {

            SqlCommand cmd = new SqlCommand("Update Employees set Name=@Name,Phone=@Phone,Address=@Address where ID=@ID ");
            cmd.Parameters.AddWithValue("@ID", _id);
            cmd.Parameters.AddWithValue("@Name", _name);
            cmd.Parameters.AddWithValue("@Phone", _phone);
            cmd.Parameters.AddWithValue("@Address", _address);

            return DALPhoneBook.DML(cmd);//on the fly
        }

        internal static int DeleteContact(int v, string text1, string text2, string text3)
        {
            SqlCommand cmd = new SqlCommand("delete from Employees where ID = @id");
            cmd.Parameters.AddWithValue("@id", v);
            return DALPhoneBook.DML(cmd);//on the fly
        }

        internal static object SearchContact(string text)
        {
            SqlCommand cmd = new SqlCommand("Select * From Employees where ID like '%" + text + "%'or Name Like'%" + text + "%'or Phone Like'%" + text + "%'or Address Like'%" + text + "%'");
            return DALPhoneBook.Select(cmd);//On the Fly
        }
    }
}
