import socket
import json

# Set up server
server_ip = 'localhost'   # Use 'localhost' for connections on the same machine
server_port = 25001       # Ensure this port matches the one in your Unity client

# Create a socket object
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    # Bind the socket to a specific address and port
    s.bind((server_ip, server_port))

    # Enable the server to accept connections
    s.listen()

    print(f"Server is listening on {server_ip}:{server_port}")

    while True:
        # Wait for an incoming connection
        client, addr = s.accept()
        with client:
            print(f"Connected by {addr}")

            # Receive the data in small chunks
            data = client.recv(1024)

            # If data is received
            if data:
                # Decode data from bytes to string
                data_str = data.decode('utf-8')

                # Load JSON data
                json_data = json.loads(data_str)

                # Print JSON data
                print(f"Received data: {json_data}")
