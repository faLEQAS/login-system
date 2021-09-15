from login import login

from register import register

def get_input(): #used in both register and login so thought i'd just put it here and import it
    username = input("enter the username\n")
    password = input("enter the password\n")

    return username, password

def main():
    choice = input("press enter to register or type anything to login")

    if choice == "":
        register()
    else:
        login()

main()