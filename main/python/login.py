import hashlib
import sqlite3

def validate_credintals(username, password):

	conn = sqlite3.connect("database.db")

	c = conn.cursor()

	temppass = password

	password = password.encode('utf-8')


	password = hashlib.md5(password).hexdigest()

	if password == temppass:
		return False

	tempuser, temppass = None, None

	c.execute("SELECT username FROM users WHERE username = ? AND password = ?",(username, password))
	exists = c.fetchall()
	c.close()
	if exists != []:
		return True;



	return False


def get_input():
	username = input("enter the username\n")
	password = input("enter the password\n")

	return username, password


def login():
	username, password = get_input()

	isvalid = validate_credintals(username, password)

	if isvalid: #reveal your biggest secret
		print("\ni don't like cake :(")
	else:
		print("\nget lost mortal")


login()