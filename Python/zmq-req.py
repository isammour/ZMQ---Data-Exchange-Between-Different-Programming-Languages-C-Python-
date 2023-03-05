import zmq
import json

context = zmq.Context()
socket = context.socket(zmq.REQ)
socket.connect("tcp://127.0.0.1:5555")

sentMessage = {
    "Name": "Ibrahim",
    "Age": 27,
    "Country": "Lebanon"
}

sentMessageJson = json.dumps(sentMessage)    
socket.send_json(sentMessageJson)

socket.close()
context.term()