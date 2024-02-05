package main

import (
	Controller_Scraping "ProxyRotation/Controller/Scraping"
	"net/http"
)

func main() {

	http.HandleFunc("/api/scraping", Controller_Scraping.GetIp)
	http.ListenAndServe(":8080", nil)
}
