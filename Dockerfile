FROM  golang:alpine3.18

WORKDIR /app

COPY . .

RUN go install github.com/go-delve/delve/cmd/dlv@latest 
RUN go install golang.org/x/tools/gopls@latest
