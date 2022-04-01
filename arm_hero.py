import socketio
import asyncio
from Arm_Lib import Arm_Device
import sys
import time

sio = socketio.AsyncClient()
Arm = Arm_Device()
time.sleep(.1)
buzzer = 0
alive=True

@sio.on('unity-update')
def on_message(data):
    global buzzer
    global alive
    print(data)
    data = [float(x) for x in data.split()]
    if len(data) == 6:
        if data[0] <= 180 and data[0] >= 0:
            Arm.Arm_serial_servo_write(1,data[0],10)
            time.sleep(.1)

        #Why was Spot tired after his journey?
        #He had a Hard Drive :joy:

        threshold = data[1]*3 + data[2]*2 + data[3]
        if threshold >= 260 and threshold <= 700:
            buzzer = 0
            Arm.Arm_serial_servo_write(2,data[1],10)
            time.sleep(.1)
            Arm.Arm_serial_servo_write(3,data[2],10)
            time.sleep(.1)
            if data[3] <= 190 and data[3] >= -40:
                Arm.Arm_serial_servo_write(4,data[3],10)
                time.sleep(.1)
            if data[4] <= 180:
                Arm.Arm_serial_servo_write(5,data[4],10)
                time.sleep(.1)
            if data[5] <= 180:
                Arm.Arm_serial_servo_write(6,data[5],10)
        else:
            print(f"Death count {buzzer}")
            if buzzer==5 and alive:
                alive=False
                Arm.Arm_Buzzer_On()
                time.sleep(3)
                Arm.Arm_Buzzer_Off()
                print("They dead bro")
                sys.exit()

            buzzer += 1
            Arm.Arm_Buzzer_On(1)
            time.sleep(1)
            Arm.Arm_Buzzer_Off()
        print("movement complete")
    else:
        print("malformed data passed in.")


async def main():
    await sio.connect("https://hack-usu-robot-proxy.herokuapp.com")
    await sio.wait()

if __name__ == '__main__':
    asyncio.run(main())
