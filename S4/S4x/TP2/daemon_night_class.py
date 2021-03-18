#!/usr/bin/python3
# -*- coding: utf8 -*-

# author: Kellian GOFFIC        09/02/2021
# usage: daemon_night_class.py

import threading, time

class Clock(threading.Thread):
    """ Thread daemon qui fait office de timer"""

    def __init__(self, interval):
        threading.Thread.__init__(self)

        self.daemon = True
        self.interval = interval

    def run(self):
        while True:
            time.sleep(self.interval)
            print("ZZzzZZzz...\t\t%s" % time.ctime() )

Clock(1).start()
# c = Clock(1) ; c.start()

print("Endormissement")
for i in range(3):
    print("Cycle %i" %(i+1))
    print("phase de sommeil leger")
    time.sleep(2.5)
    print("phase de sommeil lent profodnd")
    time.sleep(3.5)
    print("phase de sommeil paradoxal")
    time.sleep(2)
    print("phase intermediaire")
    time.sleep(1)

print("DRINGGG ! Reveil")
