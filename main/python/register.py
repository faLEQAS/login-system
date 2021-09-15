import sqlite3
import hashlib
from main import get_input


def register():
	username, password = get_input()

	password = password.encode('utf-8')

	password = hashlib.md5(password).hexdigest()

	conn = sqlite3.connect("database.db")

	c = conn.cursor()
	c.execute("SELECT username FROM users WHERE username = ?",(username,))
	exists = c.fetchall()
	if exists == []:
		c.execute("INSERT INTO users VALUES(?, ?)", (username, password))
		print("registration done")

	else:
		print("username already exists.\n")
		register()
	conn.commit()

	conn.close()

register()