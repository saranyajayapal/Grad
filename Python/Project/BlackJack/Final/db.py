import sqlite3
from contextlib import closing
from objects import Session


def make_session(row):
    return Session(row["sessionID"], row["startTime"], row["startMoney"], row["stopTime"], row["stopMoney"])


conn = None


def connect():
    global conn
    if not conn:
        DB_FILE = "session_db.sqlite"       
    conn = sqlite3.connect(DB_FILE)
    conn.row_factory = sqlite3.Row      # so we can access columns by their names from the query result


def create_session():
    query = '''CREATE TABLE IF NOT EXISTS Session (sessionID INTEGER PRIMARY KEY, startTime TEXT, startMoney REAL, stopTime TEXT, stopMoney REAL)''' 
                    
    with closing(conn.cursor()) as c:
        c.execute(query)
        session = get_last_session()
        if session is None:
            query = '''INSERT INTO Session (sessionID, startTime, startMoney, stopTime, stopMoney)
                VALUES (0, 'x', 199, 'y', 199)'''
            c.execute(query)
        conn.commit()
        

def get_last_session():
    query = '''SELECT * FROM Session ORDER BY sessionID DESC'''
    with closing(conn.cursor()) as c:
        c.execute(query)
        row = c.fetchone()
        if row is None:
            return None
        else:
            return make_session(row)
        #return row


def add_session(s):
    query = '''INSERT INTO Session (sessionID, startTime, startMoney, stopTime, stopMoney) 
                    VALUES (?, ?, ?, ?, ?)'''
    with closing(conn.cursor()) as c:
        c.execute(query, (s.sid, s.start_time, s.start_money, s.stop_time, s.stop_money))
        conn.commit()
        

def close():
    if conn:
        conn.close()


def main():
    connect()
    create_session()
    #newSess = Session(
    #add_session
    session = get_last_session()
    print(session)
    #print("Money:", session["stopMoney"])
    print("Money:", session.stop_money)
    close()


if __name__ == "__main__":
    main()
