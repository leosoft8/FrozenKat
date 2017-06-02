using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;


public class HighScoreManager : MonoBehaviour {


	private string connectionString;
	private List<Tuple> m_HighestScores;


	void Awake () {
		connectionString = "URI=file:" +  Application.streamingAssetsPath + "/HighScoreDB.db";



		m_HighestScores = new List<Tuple> ();
		using(IDbConnection dbConnection = new SqliteConnection(connectionString))
		{
			dbConnection.Open();

			using(IDbCommand dbCmd = dbConnection.CreateCommand())
			{
				string sqlQuery = "Select * from HighScore";
				dbCmd.CommandText = sqlQuery;

				using (IDataReader reader = dbCmd.ExecuteReader())
				{
					Tuple auxTuple;

					while (reader.Read()) {
						auxTuple = new Tuple (reader.GetInt32 (2), reader.GetString (1));
						m_HighestScores.Add (auxTuple);
					}
					dbConnection.Close ();
					reader.Close ();
				}



			}

		}
	}
		

	public List<Tuple> GetHighestScores(){
		return m_HighestScores;

	}

	public void InsertScore(string name, int newScore)
	{

		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			dbConnection.Open ();

			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

				string sqlQuery = String.Format("INSERT INTO HighScore (Name, Score) VALUES (\"{0}\", \"{1}\")",name,newScore);
				dbCmd.CommandText = sqlQuery;
				dbCmd.ExecuteScalar();
				dbConnection.Close();
			}
		}
	


	
	}

	public void DeleteScore(int score, string name)
	{
		using (IDbConnection dbConnection = new SqliteConnection (connectionString)) {
			dbConnection.Open ();

			using (IDbCommand dbCmd = dbConnection.CreateCommand ()) {

					string command = String.Format ("DELETE FROM HighScore WHERE Score = \"{0}\" AND Name = \"{1}\"", score, name);
					dbCmd.CommandText = command;
					dbCmd.ExecuteScalar();
					dbConnection.Close ();
				}
			
		}
	}




}
