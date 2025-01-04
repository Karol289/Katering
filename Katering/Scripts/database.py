import pyodbc
import pandas as pd


class SQLConnection:

    #server = 'DESKTOP-7KAND8P' 
    #database = 'KateringDB' 
    
    def __init__(self, serverName, databaseName):
        
        self.server = serverName
        self.database = databaseName
        self.cnxn = pyodbc.connect('DRIVER={SQL Server};SERVER='+self.server+';DATABASE='+self.database+';UID=')
        self.cursor = self.cnxn.cursor()
        
    def queryAsDataframe(self, query):
        
        df = pd.read_sql(query, self.cnxn)
        
        return df
        
        