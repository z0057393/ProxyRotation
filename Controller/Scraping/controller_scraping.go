package scraping

import (
	"fmt"
	"net/http"
	"os"
	"strings"

	"github.com/gocolly/colly"
)

func Greet() string {
	return "proxy"
}

type server struct {
	ip   string
	port string
}

func GetIp(writer http.ResponseWriter, request *http.Request) {

	// var ListOfServer []server

	collector := colly.NewCollector()

	collector.OnError(func(_ *colly.Response, err error) {
		writer.WriteHeader(404)
		writer.Write([]byte("Something went wrong..."))
	})

	collector.OnScraped(func(r *colly.Response) {
		writer.WriteHeader(200)
		writer.Header().Set("Content-Type", "application/json")

		result := strings.Split(string(r.Body), "\r\n")

		file, err := os.Create("Data/ip.txt")
		if err != nil {
			fmt.Println("Erreur lors de la création du fichier :", err)
			return
		}
		defer file.Close()

		// Écrire le contenu du tableau dans le fichier
		for _, ligne := range result {
			_, err := file.WriteString(ligne + "\n")
			if err != nil {
				fmt.Println("Erreur lors de l'écriture dans le fichier :", err)
				return
			}
		}

		writer.Write([]byte("ok"))
	})

	collector.OnHTML("body", func(e *colly.HTMLElement) {

	})

	collector.Visit("https://api.proxyscrape.com/v3/free-proxy-list/get?request=displayproxies")

}
