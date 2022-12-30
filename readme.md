

# Run jsonserver
* docker build -t jsonserver -f Dockerfile .
* docker run -d --rm --name jsonserver4 -p 49160:8080 jsonserver
* http://localhost:49160/users

# Run Mock-Server
docker run -d --name mockserver --rm -p 1080:1080 -v ${PWD}/tests:/tests --env MOCKSERVER_INITIALIZATION_JSON_PATH=/tests/data/expectations.json mockserver/mockserver

* http://localhost:1080/mockserver/dashboard
* http://localhost:1080/api/colors returns from local expectations.json
* http://localhost:1080/49160/colors > forwards jsonserver http://localhost:49160/colors

# Run asp.net mvc application
docker build -t dnapp .
docker run -d --rm -p 8082:80 --name dnapp dnapp
http://localhost:8082