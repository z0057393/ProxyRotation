package controller

import (
	"encoding/json"
	"net/http"
)

func Greet() string {
	return "Hello world"
}

func Rotation(writer http.ResponseWriter, request *http.Request) {
	request.ParseMultipartForm(10 << 20)
	var content string = request.FormValue("content")
	var codeData []byte

	writer.Header().Set("Content-Type", "application/json")

	if content == "" {
		writer.WriteHeader(400)
		json.NewEncoder(writer).Encode(
			"Could not determine the desired QR code content.",
		)
		return
	}

	writer.Header().Set("Content-Type", "image/png")
	writer.Write(codeData)
}
