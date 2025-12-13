import socket
import sqlite3
import json
import uuid

def create_db():
    conn = sqlite3.connect("applications.db")
    cur = conn.cursor()
    cur.execute("""
        CREATE TABLE IF NOT EXISTS applications(
            app_id TEXT PRIMARY KEY,
            name TEXT,
            address TEXT,
            qualification TEXT,
            course TEXT,
            start_year TEXT,
            start_month TEXT
        )
    """)
    conn.commit()
    conn.close()

def save_application(data):
    app_id = str(uuid.uuid4())
    conn = sqlite3.connect("applications.db")
    cur = conn.cursor()
    cur.execute("""
        INSERT INTO applications(app_id, name, address, qualification, course, start_year, start_month)
        VALUES(?,?,?,?,?,?,?)
    """, (
        app_id,
        data["name"],
        data["address"],
        data["qualification"],
        data["course"],
        data["year"],
        data["month"]
    ))
    conn.commit()
    conn.close()
    return app_id

def start_server():
    create_db()
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    ip = "127.0.0.1"
    port = 9001
    server.bind((ip, port))
    server.listen(5)

    print(f"Server running on {ip}:{port}")

    while True:
        client, addr = server.accept()
        received = client.recv(4096).decode()
        data = json.loads(received)
        reg_no = save_application(data)
        client.send(reg_no.encode())
        client.close()

if __name__ == "__main__":
    start_server()
