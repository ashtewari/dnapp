

# Run jsonserver
* docker build -t jsonserver -f Dockerfile .
* docker run -d --rm --name jsonserver -v ${PWD}:/tmp -p 49160:8080 jsonserver /tmp/todos.json
* http://localhost:49160/users

# Run Mock-Server
docker run -d --name mockserver --rm -p 1080:1080 -v ${PWD}/tests:/tests --env MOCKSERVER_INITIALIZATION_JSON_PATH=/tests/data/expectations.json mockserver/mockserver

* http://localhost:1080/mockserver/dashboard
* http://localhost:1080/api/colors returns from local expectations.json
* http://localhost:1080/49160/colors > forwards jsonserver http://localhost:49160/colors

# Run asp.net mvc application
* docker build -t dnapp .
* docker run -d --rm -p 8082:80 -e API_BASEURL=http://172.17.0.1:1080/api/ --name dnapp dnapp
* http://localhost:8082
* http://localhost:8082/Home/Colors 
    > API_BASEURL=http://172.17.0.1:1080/api/ returns from mockserver
    > API_BASEURL=http://172.17.0.1:49160/ returns from jonserver directly
    > API_BASEURL=http://172.17.0.1:1080/49160/ returns from jsonserver (forwarded by mockserver)