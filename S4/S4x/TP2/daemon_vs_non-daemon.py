#!/usr/bin/python3

# author: Kellian GOFFIC        09/02/2021
# usage: daemon_vs_non-daemon.py

import threading, time

def daemon():
    print("daemon is starting")
    time.sleep(2)
    print("daemon is existing")

def non_daemon():
    print("non daemon is starting")
    print("non daemon is exiting")

d = threading.Thread(target=daemon())
d.daemon = True
t = threading.Thread(target=non_daemon())
d.start()
time.sleep(0.1)
t.start()

t.join() ; d.join()