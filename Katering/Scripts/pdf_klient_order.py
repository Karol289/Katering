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
import matplotlib.pyplot as plt
import pandas as pd


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

    def add_client_info(self, client_name, client_address, client_contact, data):
      
        self.pdf.set_font("Arial", size=12)
        self.pdf.cell(0, 10, f"Imie: {client_name}", ln=True)
        self.pdf.cell(0, 10, f"Nazwisko: {client_address}", ln=True)
        self.pdf.cell(0, 10, f"Email: {client_contact}", ln=True)
        if data != 0:
            self.pdf.cell(0, 10, f"Data zamównienia: {data}", ln=True)
        self.pdf.ln(10)

    def add_order_details(self, df):
        # Ustawienia czcionki
        self.pdf.set_font("Arial", size=12)

        # Nagłówki tabeli
        self.pdf.cell(60, 10, "Produkt", border=1, align="C")
        self.pdf.cell(30, 10, "Ilosc", border=1, align="C")
        self.pdf.cell(30, 10, "Cena", border=1, align="C")
        self.pdf.cell(30, 10, "Suma", border=1, align="C")
        self.pdf.ln(10)

        total = 0

        # Iteracja przez wiersze DataFrame
        for _, row in df.iterrows():
            name = row["MealName"]  # Nazwa produktu
            quantity = row.get("Quantity", 1)  # Ilość (domyślnie 1, jeśli brak kolumny Quantity)
            price = row["Price"]  # Cena jednostkowa
            item_total = quantity * price  # Suma za produkt
            total += item_total

            # Wiersz tabeli
            self.pdf.cell(60, 10, name, border=1)
            self.pdf.cell(30, 10, str(quantity), border=1, align="C")
            self.pdf.cell(30, 10, f"{price:.2f} PLN", border=1, align="C")
            self.pdf.cell(30, 10, f"{item_total:.2f} PLN", border=1, align="C")
            self.pdf.ln(10)

        # Łączna kwota
        self.pdf.ln(5)
        self.pdf.set_font("Arial", size=12, style="B")
        self.pdf.cell(0, 10, f"Laczna kwota: {total:.2f} PLN", ln=True, align="R")

    def add_logo(self, logo_path, x=170, y=8, w=30):
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
                  
    def add_order_details2(self, df):
       # Ustawienia czcionki
       self.pdf.set_font("Arial", size=12)

       # Nagłówki tabeli
       self.pdf.cell(60, 10, "Produkt", border=1, align="C")
       self.pdf.cell(30, 10, "Ilosc", border=1, align="C")
       self.pdf.cell(30, 10, "Cena", border=1, align="C")
       self.pdf.cell(30, 10, "Suma", border=1, align="C")
       self.pdf.ln(10)

       total = 0

       # Obliczanie ilości (na podstawie unikalnych MealOrderId dla MealName) i sumowanie ceny
       grouped_df = df.groupby('MealName').agg(
           quantity=('MealOrderId', 'nunique'),  # Ilość to liczba unikalnych MealOrderId
           price=('Price', 'first')  # Cena jednostkowa, bierzemy pierwszą cenę (zakładając, że cena jest taka sama)
       ).reset_index()

       # Iteracja przez zgrupowane dane i dodanie do tabeli
       for _, row in grouped_df.iterrows():
           name = row["MealName"]  # Nazwa produktu
           quantity = row["quantity"]  # Zsumowana ilość (unikalne MealOrderId)
           price = row["price"]  # Cena jednostkowa
           item_total = quantity * price  # Suma za produkt
           total += item_total

           # Wiersz tabeli
           self.pdf.cell(60, 10, name, border=1)
           self.pdf.cell(30, 10, str(quantity), border=1, align="C")
           self.pdf.cell(30, 10, f"{price:.2f} PLN", border=1, align="C")
           self.pdf.cell(30, 10, f"{item_total:.2f} PLN", border=1, align="C")
           self.pdf.ln(10)

       # Dodanie wszystkich posiłków, które nie pojawiły się w zamówieniu (sprzedane 0 razy)
       all_meals = df['MealName'].unique()
       sold_meals = grouped_df['MealName'].tolist()

       for meal in all_meals:
           if meal not in sold_meals:
               self.pdf.cell(60, 10, meal, border=1, align="C")
               self.pdf.cell(30, 10, "0", border=1, align="C")
               self.pdf.cell(30, 10, "0.00 PLN", border=1, align="C")
               self.pdf.cell(30, 10, "0.00 PLN", border=1, align="C")
               self.pdf.ln(10)

       # Łączna kwota zamówienia
       self.pdf.ln(5)
       self.pdf.set_font("Arial", size=12, style="B")
       self.pdf.cell(0, 10, f"Laczna kwota: {total:.2f} PLN", ln=True, align="R")

    def add_order_details3(self, df):
        # Ustawienia czcionki
        self.pdf.set_font("Arial", size=12)

        # Nagłówki tabeli
        self.pdf.cell(60, 10, "Produkt", border=1, align="C")
        self.pdf.cell(30, 10, "Data", border=1, align="C")
        self.pdf.cell(30, 10, "Ilosc", border=1, align="C")
        self.pdf.cell(30, 10, "Suma", border=1, align="C")
        self.pdf.ln(10)

        # Grupowanie danych po MealName i Date, liczenie unikalnych MealOrderId
        grouped_df = df.groupby(['MealName', 'Date']).agg(
            quantity=('MealOrderId', 'nunique'),  # Liczymy unikalne MealOrderId dla każdego posiłku w danym dniu
            price=('Price', 'first')  # Cena posiłku, zakładając, że cena jest taka sama dla wszystkich zamówień tego posiłku
        ).reset_index()

        # Wypisywanie danych do PDF
        total = 0
        for _, row in grouped_df.iterrows():
            name = row["MealName"]  # Nazwa produktu
            date = row["Date"]  # Data
            quantity = row["quantity"]  # Ilość
            price = row["price"]  # Cena jednostkowa
            item_total = quantity * price  # Suma za dany dzień i posiłek
            total += item_total

            # Wiersz tabeli
            self.pdf.cell(60, 10, name, border=1)
            self.pdf.cell(30, 10, str(date), border=1, align="C")
            self.pdf.cell(30, 10, str(quantity), border=1, align="C")
            self.pdf.cell(30, 10, f"{item_total:.2f} PLN", border=1, align="C")
            self.pdf.ln(10)

        # Łączna kwota
        self.pdf.ln(5)
        self.pdf.set_font("Arial", size=12, style="B")
        self.pdf.cell(0, 10, f"Laczna kwota: {total:.2f} PLN", ln=True, align="R")



def pdfPojedynczeZamowienia(df):
    
    pdf = PDFReport("Raport zamowienia")
    pdf.add_page()
    pdf.add_logo("../Scripts/images/logo.png") 
    pdf.set_title()
    pdf.add_client_info(df.loc[0, 'UserName'], df.loc[0, 'Surname'], df.loc[0, 'Email'], df.loc[0, 'Date'])
    pdf.add_order_details(df.drop(['UserName', 'Surname', 'Email', 'Date', 'MealId', 'Discount'], axis = 1))
    
    return pdf

def pdfWEszystkieZamowienia(df):
    
    pdf = PDFReport("Raport zamownien")
    pdf.add_page()
    pdf.add_logo("../Scripts/images/logo.png") 
    pdf.set_title()
    pdf.add_client_info(df.loc[0, 'UserName'], df.loc[0, 'Surname'], df.loc[0, 'Email'], 0)
    groups = df.groupby("OrderId")
    
    for order_id, group in groups:
        print(group.head())
        pdf.add_text(f"Zamowienie nr: {order_id}")
        pdf.add_text(f"Data: {group['Date'].max()}")
        pdf.add_order_details(group.drop(['UserName', 'Surname', 'Email', 'Date', 'MealId', 'Discount', 'OrderId'], axis = 1))
       

    pdf.pdf.ln(5)
    pdf.pdf.set_font("Arial", size=12, style="B")
    pdf.pdf.cell(0, 10, f"Laczna kwota wszystkich zamownien: {df['Price'].sum():.2f} PLN", ln=True, align="R")
    
    
    df['Date'] = pd.to_datetime(df['Date'])
    df['Month_Year'] = df['Date'].dt.to_period('M')

    # Calculate total spending per month
    monthly_spending = df.groupby('Month_Year')['Price'].sum()

    # Plot
    plt.figure(figsize=(8, 6))
    monthly_spending.plot(kind='bar', color='skyblue', edgecolor='black')
    plt.title('Wydatki na kazdy miesiac', fontsize=16)
    plt.xlabel('Miesiac-Rok', fontsize=12)
    plt.ylabel('Laczne wydatki', fontsize=12)
    plt.xticks(rotation=45, ha='right')
    plt.tight_layout()
    
    plt.savefig("../Scripts/images/1.png", format="png", dpi=180)
    
    pdf.add_page()
    pdf.pdf.image("../Scripts/images/1.png", x=30,y=0, w=150, h=130)
    
    return pdf


    
    
    
    
def pdfWEszystkieZamowieniaMod(df):
    
    pdf = PDFReport("Raport zamownien")
    pdf.add_page()
    pdf.add_logo("../Scripts/images/logo.png") 
    pdf.set_title()
    groups = df.groupby("OrderId")
    
    for order_id, group in groups:
        print(group.head())
        pdf.add_text(f"Zamowienie nr: {order_id}")
        pdf.add_text(f"Data: {group['Date'].max()}")
        pdf.add_order_details(group.drop(['MealId', 'Discount', 'OrderId'], axis = 1))
    
    
    df['Date'] = pd.to_datetime(df['Date']).dt.date

    # Grupowanie danych po dacie i liczenie liczby wystąpień w każdej dacie
    sales_per_day = df.groupby('Date').size()

    # Tworzenie wykresu
    plt.figure(figsize=(10,6))
    sales_per_day.plot(kind='bar', color='skyblue')

    # Dodanie tytułu i etykiet
    plt.title('Liczba sprzedanych dań na dzień', fontsize=14)
    plt.xlabel('Data', fontsize=12)
    plt.ylabel('Liczba sprzedanych dań', fontsize=12)

    # Wyświetlenie wykresu
    plt.xticks(rotation=45)
    plt.tight_layout()
    
    plt.savefig("../Scripts/images/1.png", format="png", dpi=180)
    
    pdf.add_page()
    pdf.pdf.image("../Scripts/images/1.png", x=30,y=0, w=150, h=130)
    

    # Obliczenie łącznej wartości sprzedaży (cena * liczba dań)
    df['TotalSale'] = df['Price']  # Można uwzględnić zniżki, jeśli chcesz, np. `df['Price'] - (df['Discount'] / 100) * df['Price']`
    total_sales_per_day = df.groupby('Date')['TotalSale'].sum()

    # Tworzenie wykresu
    plt.figure(figsize=(10,6))
    total_sales_per_day.plot(kind='bar', color='lightgreen')

    # Dodanie tytułu i etykiet
    plt.title('Łączne zarobki na dzień', fontsize=14)
    plt.xlabel('Data', fontsize=12)
    plt.ylabel('Zarobki (w zl)', fontsize=12)

    # Wyświetlenie wykresu
    plt.xticks(rotation=45)
    plt.tight_layout()
    
    plt.savefig("../Scripts/images/2.png", format="png", dpi=180)
    
    pdf.add_page()
    pdf.pdf.image("../Scripts/images/2.png", x=30,y=0, w=150, h=130)
    
    
    
    return pdf



def pdfKategoriaMod(df):
    
    pdf = PDFReport("Raport kategorii zywieniowej")
    pdf.add_page()
    pdf.add_logo("../Scripts/images/logo.png") 
    pdf.set_title()
    
    pdf.add_text(f"Kategoria zywieniowa: {df.loc[0, 'CathegoryName']}")
    
    pdf.add_order_details2(df)
    
    # Obliczanie ilości posiłków sprzedanych (unikalne MealOrderId dla MealName)
    grouped_df = df.groupby('MealName').agg(
        quantity=('MealOrderId', 'nunique'),  # Ilość to liczba unikalnych MealOrderId
        price=('Price', 'first')  # Cena jednostkowa, bierzemy pierwszą cenę (zakładając, że cena jest taka sama)
    ).reset_index()
    
    # Generowanie wykresu z ilościami posiłków
    plt.figure(figsize=(10, 6))
    plt.bar(grouped_df['MealName'], grouped_df['quantity'], color='skyblue')
    plt.title('Ilość sprzedanych posiłków', fontsize=14)
    plt.xlabel('Nazwa posiłku', fontsize=12)
    plt.ylabel('Ilość sprzedanych porcji', fontsize=12)
    plt.xticks(rotation=45, ha='right')
    plt.tight_layout()
    
    plt.savefig("../Scripts/images/1.png", format="png", dpi=180)
    
    pdf.add_page()
    pdf.pdf.image("../Scripts/images/1.png", x=30,y=0, w=150, h=130)
    
    return pdf


def pdfMealMod(df):
    
    pdf = PDFReport("Raport posilku")
    pdf.add_page()
    pdf.add_logo("../Scripts/images/logo.png") 
    pdf.set_title()
    
    pdf.add_text(f"Posilek: {df.loc[0, 'MealName']}")
    
    pdf.add_order_details3(df=df)
    
    
    grouped_df = df.groupby(['MealName', 'Date']).agg(
        quantity=('MealOrderId', 'nunique')  # Liczymy unikalne MealOrderId, aby uzyskać ilość sprzedanych posiłków
    ).reset_index()

    # Tworzenie wykresu
    plt.figure(figsize=(10, 6))
    plt.bar(grouped_df['Date'].astype(str), grouped_df['quantity'], color='skyblue')
    plt.title(f'Ilość sprzedanych {df.loc[0, "MealName"]} na dzień', fontsize=14)
    plt.xlabel('Data', fontsize=12)
    plt.ylabel('Ilość sprzedanych porcji', fontsize=12)
    plt.xticks(rotation=45, ha='right')
    plt.tight_layout()
    
    plt.savefig("../Scripts/images/1.png", format="png", dpi=180)
    
    pdf.add_page()
    pdf.pdf.image("../Scripts/images/1.png", x=30,y=0, w=150, h=130)
    
    return pdf
     