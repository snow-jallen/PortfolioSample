docker rm -f pg

docker run -d -p 5432:5432 --name pg --restart always -e POSTGRES_PASSWORD=password postgres