FROM debian:10-slim

RUN apt-get update \
  && apt-get install -y curl \
  && curl -sL https://deb.nodesource.com/setup_12.x | bash - \
  && apt-get install -y nodejs

RUN npm install -g json-server

ENTRYPOINT ["json-server", "--watch", "--port", "8080", "--host", "0.0.0.0", "--routes", "/tmp/routes.json"]

CMD ["/tmp/database.json"]