# import os
# import webbrowser
# from fpdf import FPDF






# class PDF:
    
#     def __init__(self , title="Default Title"):
#         self.pdf = FPDF()
#         self.title = title
    
#     def addPage (self):
#         self.pdf.add_page()
      
    
#     def setTitle(self):
#         self.pdf.set_font("Arial", size=16, style="B")
#         self.pdf.cell(0, 10, self.title, ln=True, align="C")
#         self.pdf.ln(10)
    
#     def addText(self, text, font="Arial", size=12):
       
#         self.pdf.set_font(font, size=size)
#         self.pdf.multi_cell(0, 10, text)


#     def addImage(self, image_path, x=10, y=None, w=100):
     
#         self.pdf.image(image_path, x=x, y=y, w=w)

#     def savePDF(self, filename):
#         self.pdf.output(filename)  
    
#     def openPDF(self , filename):
#         if os.path.exists(filename):  
#             webbrowser.open_new_tab(filename)
#         else:
#             print(f"Plik {filename} nie istnieje!")
    
      
        
# P = PDF("tytul")

# P.addPage()
# P.addText("LIS", size= 18)
# P.addText("Lisek chytrusek.")
# P.addImage("D:\Pobrane\lis.jpg", w=80)
# P.savePDF("example.pdf")
# filename = "example.pdf"
# P.openPDF("example.pdf")


import os
import webbrowser
from fpdf import FPDF


class PDFReport:
   

    def __init__(self, title="Raport"):
        self.pdf = FPDF()
        self.title = title

    def add_page(self):
        
        self.pdf.add_page()

    def set_title(self):
        
        self.pdf.set_font("Arial", size=16, style="B")
        self.pdf.cell(0, 10, self.title, ln=True, align="C")
        self.pdf.ln(10)

    def add_text(self, text, font="Arial", size=12):
       
        self.pdf.set_font(font, size=size)
        self.pdf.multi_cell(0, 10, text)

    def add_client_info(self, client_name, client_address, client_contact):
      
        self.pdf.set_font("Arial", size=12)
        self.pdf.cell(0, 10, f"Klient: {client_name}", ln=True)
        self.pdf.cell(0, 10, f"Adres: {client_address}", ln=True)
        self.pdf.cell(0, 10, f"Kontakt: {client_contact}", ln=True)
        self.pdf.ln(10)

    def add_order_details(self, items):
       
        self.pdf.set_font("Arial", size=12)
        self.pdf.cell(60, 10, "Produkt", border=1, align="C")
        self.pdf.cell(30, 10, "Ilosc", border=1, align="C")
        self.pdf.cell(30, 10, "Cena", border=1, align="C")
        self.pdf.cell(30, 10, "Suma", border=1, align="C")
        self.pdf.ln(10)

        total = 0
        for item in items:
            name = item["name"]
            quantity = item["quantity"]
            price = item["price"]
            item_total = quantity * price
            total += item_total

            self.pdf.cell(60, 10, name, border=1)
            self.pdf.cell(30, 10, str(quantity), border=1, align="C")
            self.pdf.cell(30, 10, f"{price:.2f} PLN", border=1, align="C")
            self.pdf.cell(30, 10, f"{item_total:.2f} PLN", border=1, align="C")
            self.pdf.ln(10)

        self.pdf.ln(5)
        self.pdf.set_font("Arial", size=12, style="B")
        self.pdf.cell(0, 10, f"Laczna kwota: {total:.2f} PLN", ln=True, align="R")

    def add_logo(self, logo_path, x=10, y=8, w=30):
        """Dodaje logo na początku raportu."""
        if os.path.exists(logo_path):
            self.pdf.image(logo_path, x=x, y=y, w=w)
        else:
            print(f"Blad: Plik logo '{logo_path}' nie istnieje!")

    def save_pdf(self, filename):
        """Zapisuje plik PDF."""
        self.pdf.output(filename)

    def open_pdf(self, filename):
        """Otwiera plik PDF."""
        if os.path.exists(filename):
            webbrowser.open_new_tab(filename)
        else:
            print(f"Blad: Plik '{filename}' nie istnieje!")


# Przykładowe wywołanie
if __name__ == "__main__":
    # Dane przykładowe
    client_name = "Jan Kowalski"
    client_address = "ul. Kwiatowa 10, Warszawa"
    client_contact = "123-456-789"
    order_items = [
        {"name": "Pizza Margherita", "quantity": 2, "price": 25.0},
        {"name": "Napoj Cola", "quantity": 3, "price": 5.0},
        {"name": "Paluchy chlebowe", "quantity" : 1, "price" : 13.0}
    ]

    # Generowanie raportu
    pdf = PDFReport("Raport zamowienia")
    pdf.add_page()
    pdf.add_logo("D:\IO_projekt\Katering\Katering\Scripts\images\lis.jpg")  # Dodaj logo firmy (opcjonalnie)
    pdf.set_title()
    pdf.add_client_info(client_name, client_address, client_contact)
    pdf.add_order_details(order_items)
    pdf.save_pdf("raport_zamowienia.pdf")
    pdf.open_pdf("raport_zamowienia.pdf")

         
     