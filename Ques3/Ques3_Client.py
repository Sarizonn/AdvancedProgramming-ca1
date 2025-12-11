import socket
import json

def get_user_input():
    name = input("Enter full name: ")
    address = input("Enter address: ")
    qualification = input("Enter educational qualification: ")
    course = input("Course (Cyber Security / ISC / Data Analytics): ")
    year = input("Start year (e.g. 2025): ")
    month = input("Start month (e.g. September): ")

    return {
        "name": name,
        "address": address,
        "qualification": qualification,
        "course": course,
        "year": year,
        "month": month
    }

def send_application(data):
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect(("127.0.0.1", 9000))
    client.send(json.dumps(data).encode())
    reg_no = client.recv(1024).decode()
    client.close()
    return reg_no

def start_client():
    data = get_user_input()
    reg_no = send_application(data)
    print("Your Registration Number is:", reg_no)

if __name__ == "__main__":
    start_client()
