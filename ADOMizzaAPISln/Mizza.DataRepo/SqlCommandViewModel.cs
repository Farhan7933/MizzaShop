using Mizza.DataRepo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mizza.DataRepo
{
    public class SqlCommandViewModel
    {
        private MySqlConnection _mySqlConn;
        public SqlCommandViewModel(string cnnName)
        {
            _mySqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings[cnnName].ConnectionString);
        }

        public DataTable GetRecords(string procedureName, string id = null)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(procedureName, _mySqlConn);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Id", id);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();

            _mySqlConn.Open();
            mySqlDataAdapter.Fill(dt);
            _mySqlConn.Close();

            return dt;
        }

        public DataTable GetRecords(string procedureName, int page, int limit)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(procedureName, _mySqlConn);
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.Parameters.AddWithValue("@Id", null);
            mySqlCommand.Parameters.AddWithValue("@page", page);
            mySqlCommand.Parameters.AddWithValue("@pageSize", limit);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();

            _mySqlConn.Open();
            mySqlDataAdapter.Fill(dt);
            _mySqlConn.Close();

            return dt;
        }

        //public DataTable GetfilteredRecord<T>(string procedureName, T filter)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand(procedureName, _mySqlConn);
        //    mySqlCommand.CommandType = CommandType.StoredProcedure;
        //    mySqlCommand = filter.GetProcedureQuery(mySqlCommand);
        //    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
        //    DataTable dt = new DataTable();

        //    _mySqlConn.Open();
        //    mySqlDataAdapter.Fill(dt);
        //    _mySqlConn.Close();

        //    return dt;
        //}

        //public DataTable GetfilteredRecord(string id, string procedureName)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand(procedureName, _mySqlConn);
        //    mySqlCommand.CommandType = CommandType.StoredProcedure;
        //    mySqlCommand.Parameters.AddWithValue("@Id", id);
        //    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
        //    DataTable dt = new DataTable();

        //    _mySqlConn.Open();
        //    mySqlDataAdapter.Fill(dt);
        //    _mySqlConn.Close();

        //    return dt;
        //}

        public bool ExecCRUD<T>(T item, string procedureName)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(procedureName, _mySqlConn);
            mySqlCommand.CommandType = CommandType.StoredProcedure;

            mySqlCommand = item.GetProcedureQuery(mySqlCommand);

            _mySqlConn.Open();
            int records = mySqlCommand.ExecuteNonQuery();
            _mySqlConn.Close();

            return records > 0;
        }
    }
}