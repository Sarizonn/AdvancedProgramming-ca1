import requests
from bs4 import BeautifulSoup
import csv
from datetime import datetime
import re

headers = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36"
}

all_hotels = []

def scrape_hotel_site(url, site_name):
    count = 0
    response = requests.get(url, headers=headers, timeout=15)
    
    if response.status_code == 200:
        soup = BeautifulSoup(response.text, 'html.parser')
        hotel_cards = soup.find_all('div', class_='hotel-card')
        
        for card in hotel_cards[:10]:
            name_tag = card.find('div', class_='hotel-name')
            location_tag = card.find('div', class_='hotel-location')
            desc_tag = card.find('div', class_='hotel-description')
            price_tag = card.find('div', class_='current-price')
            
            hotel_name = name_tag.text.strip() if name_tag else None
            location = location_tag.text.strip() if location_tag else None
            room_type = desc_tag.text.strip() if desc_tag else None
            
            price = 0
            if price_tag:
                numbers = re.findall(r'\d+', price_tag.text.strip())
                if numbers:
                    price = int(numbers[0])
            
            if hotel_name and location and room_type and price > 0:
                all_hotels.append({
                    "Hotel": hotel_name,
                    "Location": location,
                    "Room_Type": room_type,
                    "Price_Per_Night": price,
                    "Currency": "EUR",
                    "Date_Scraped": datetime.now().strftime("%Y-%m-%d %H:%M:%S")
                })
                count += 1
        
        print(f"Scraped {count} hotels from {site_name}")
    
    return count

print("Scraping hotel data...")
scrape_hotel_site("https://booking-hotels2.tiiny.site/", "DublinStays")
scrape_hotel_site("https://hotel1.tiiny.site/", "Luxe Haven")

csv_filename = "hotel_prices.csv"
with open(csv_filename, 'w', newline='', encoding='utf-8') as csvfile:
    fieldnames = ["Hotel", "Location", "Room_Type", "Price_Per_Night", "Currency", "Date_Scraped"]
    writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
    writer.writeheader()
    writer.writerows(all_hotels)

print(f"\nSaved {len(all_hotels)} records to {csv_filename}")

with open(csv_filename, 'r', encoding='utf-8') as csvfile:
    reader = csv.DictReader(csvfile)
    print(f"\n{'Hotel':<35} {'Location':<25} {'Room Type':<30} {'Price/Night':<12}")
    print("-" * 105)
    
    for row in reader:
        hotel = row['Hotel'][:33]
        location = row['Location'][:23]
        room_type = row['Room_Type'][:28]
        price = f"€{row['Price_Per_Night']}"
        print(f"{hotel:<35} {location:<25} {room_type:<30} {price:<12}")
    
    print("-" * 105)
