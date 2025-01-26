from fpdf import FPDF
from collections import Counter


class MostPopularDishReportPDF:
ss

    def __init__(self, title="Raport Najczesciej Zamawianego Dania"):
        self.pdf = FPDF()
        self.title = title

    def add_page(self):
        self.pdf.add_page()

    def set_title(self):
        self.pdf.set_font("Arial", size=16, style="B")
        self.pdf.cell(0, 10, self.title, ln=True, align="C")
        self.pdf.ln(10)

    def add_most_popular_dish(self, dish, count):
        """Dodaje informacje o najczęściej zamawianym daniu."""
        self.pdf.set_font("Arial", size=12, style="B")
        self.pdf.cell(0, 10, f"Najczesciej zamawiane danie: {dish}", ln=True)
        self.pdf.cell(0, 10, f"Liczba zamówionych porcji: {count}", ln=True)
        self.pdf.ln(10)

    def add_order_details(self, orders):
        self.pdf.set_font("Arial", size=12)
        self.pdf.cell(40, 10, "Data", border=1, align="C")
        self.pdf.cell(60, 10, "Danie", border=1, align="C")
        self.pdf.cell(40, 10, "Kategoria", border=1, align="C")
        self.pdf.cell(40, 10, "Liczba porcji", border=1, align="C")
        self.pdf.ln(10)

        for order in orders:
            self.pdf.cell(40, 10, order["date"], border=1)
            self.pdf.cell(60, 10, order["dish"], border=1)
            self.pdf.cell(40, 10, order["category"], border=1)
            self.pdf.cell(40, 10, str(order["quantity"]), border=1, align="C")
            self.pdf.ln(10)

    def save_pdf(self, filename):
        self.pdf.output(filename)

    def open_pdf(self, filename):
      
        import os, webbrowser
        if os.path.exists(filename):
            webbrowser.open_new_tab(filename)
        else:
            print(f"Blad: Plik '{filename}' nie istnieje!")


if __name__ == "__main__":
    # Dane przykładowe dla zamówień
    orders = [
        {"date": "2025-01-01", "dish": "Jajecznica", "category": "Sniadanie", "quantity": 2},
        {"date": "2025-01-03", "dish": "Zupa Pomidorowa", "category": "Obiad", "quantity": 1},
        {"date": "2025-01-10", "dish": "Kotlet Schabowy", "category": "Obiad", "quantity": 3},
        {"date": "2025-02-01", "dish": "Jajecznica", "category": "Sniadanie", "quantity": 1},
        {"date": "2025-02-15", "dish": "Kanapki", "category": "Przekaska", "quantity": 4},
        {"date": "2025-03-05", "dish": "Tiramisu", "category": "Deser", "quantity": 2},
        {"date": "2025-03-10", "dish": "Kotlet Schabowy", "category": "Obiad", "quantity": 3},
    ]

    # Zliczanie najczęściej zamawianych dań
    dishes = [order["dish"] for order in orders]
    dish_counts = Counter(dishes)
    most_popular_dish, most_popular_count = dish_counts.most_common(1)[0]

    # Generowanie raportu
    pdf = MostPopularDishReportPDF("Raport Najczesciej Zamawianego Dania")
    pdf.add_page()
    pdf.set_title()
    pdf.add_most_popular_dish(most_popular_dish, most_popular_count)
    pdf.add_order_details(orders)
    pdf.save_pdf("raport_najczesciej_zamawianego_dania_z_kategoria.pdf")
    pdf.open_pdf("raport_najczesciej_zamawianego_dania_z_kategoria.pdf")
