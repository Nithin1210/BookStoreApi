using BookStoreCommon;
using BookStoreRepository.IRepository;
using Microsoft.Extensions.Configuration;
using NlogImplemantation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BookStoreRepository.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration iconfiguration;
        public BookRepository(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        private SqlConnection con;
        private void Connection()
        {
            string connectionStr = this.iconfiguration[("ConnectionStrings:UserDbConnection")];
            con = new SqlConnection(connectionStr);
        }
        nlogOperation nlog = new nlogOperation();
        public async Task<int> AddBook(Books obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("spAddBook", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BookName", obj.BookName);
                com.Parameters.AddWithValue("@BookDescription", obj.BookDescription);
                com.Parameters.AddWithValue("@BookAuthor", obj.BookAuthor);
                com.Parameters.AddWithValue("@BookImage", obj.BookImage);
                com.Parameters.AddWithValue("@BookCount", obj.BookCount);
                com.Parameters.AddWithValue("@BookPrice", obj.BookPrice);
                com.Parameters.AddWithValue("@Rating", obj.Rating);
                con.Open();
                int result = await com.ExecuteNonQueryAsync();
                nlog.LogDebug("Book Added");
                return result;
            }
            catch (Exception ex)
            {
                nlog.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public IEnumerable<Books> GetAllBooks()
        {
            try
            {
                Connection();
                List<Books> BookList = new List<Books>();
                SqlCommand com = new SqlCommand("spGetAllBooks", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    BookList.Add(
                        new Books()
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            BookDescription = Convert.ToString(dr["BookDescription"]),
                            BookAuthor = Convert.ToString(dr["BookAuthor"]),
                            BookImage = Convert.ToString(dr["BookImage"]),
                            BookCount = Convert.ToInt32(dr["BookCount"]),
                            BookPrice = Convert.ToInt32(dr["BookPrice"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        }
                        );
                }
                foreach (var data in BookList)
                {
                    Console.WriteLine(data.BookId + "" + data.BookName);
                }
                nlog.LogDebug("Got all Books");
                return BookList;
            }
            catch (Exception ex)
            {
                nlog.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateBook(Books obj)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("spUpdateBook", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BookId", obj.BookId);
                com.Parameters.AddWithValue("@BookName", obj.BookName);
                com.Parameters.AddWithValue("@BookDescription", obj.BookDescription);
                com.Parameters.AddWithValue("@BookAuthor", obj.BookAuthor);
                com.Parameters.AddWithValue("@BookImage", obj.BookImage);
                com.Parameters.AddWithValue("@BookCount", obj.BookCount);
                com.Parameters.AddWithValue("@BookPrice", obj.BookPrice);
                com.Parameters.AddWithValue("@Rating", obj.Rating);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    nlog.LogDebug("Book Updated");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                nlog.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public bool DeleteBook(int BookId)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("spDeleteBook", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BookId", BookId);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    nlog.LogDebug("Book Deleted");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                nlog.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
  
        

        public IEnumerable<Books> GetBookById(int BookId)
        {
            try
            {
                Connection();
                List<Books> BookList = new List<Books>();
                SqlCommand com = new SqlCommand("spGetBookById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BookId", BookId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    BookList.Add(
                        new Books()
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            BookDescription = Convert.ToString(dr["BookDescription"]),
                            BookAuthor = Convert.ToString(dr["BookAuthor"]),
                            BookImage = Convert.ToString(dr["BookImage"]),
                            BookCount = Convert.ToInt32(dr["BookCount"]),
                            BookPrice = Convert.ToInt32(dr["BookPrice"]),
                            Rating = Convert.ToInt32(dr["Rating"])
                        }
                        );
                }
                nlog.LogDebug("Got the book by Id");
                return BookList;
            }
            catch (Exception ex)
            {
                nlog.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
