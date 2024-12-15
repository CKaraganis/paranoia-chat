docker stop mosquitto-broker
docker rm mosquitto-broker
docker run -d --name mosquitto-broker -p 1883:1883 -p 9001:9001 -v C:\Users\chris\mosquitto\config:/mosquitto/config -v C:\Users\chris\mosquitto\data:/mosquitto/data -v C:\Users\chris\mosquitto\log:/mosquitto/log eclipse-mosquitto

docker stop paranoia-client
docker build -f C:\Users\chris\src\Personal\Paranoia\Paranoia.Client\Dockerfile -t paranoia-client C:\Users\chris\src\Personal\Paranoia\Paranoia.Client\
docker run -d --name paranoia-client -p 5000:5000 paranoia-client
