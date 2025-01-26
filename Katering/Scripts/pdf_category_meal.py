from fpdf import FPDF


class CategoryReportPDF:

    def __init__(self, title="Raport Kategorii Zamowien"):
        self.pdf = FPDF()
        self.title = title

    def add_page(self):
        self.pdf.add_page()

    def set_title(self, category):
        self.pdf.set_font("Arial", size=16, style="B")
        self.pdf.cell(0, 10, f"{self.title} - {category}", ln=True, align="C")
        self.pdf.ln(10)

    def add_summary(self, total_orders, total_amount):
        self.pdf.set_font("Arial", size=12, style="B")
        self.pdf.cell(0, 10, f"Liczba zamowien: {total_orders}", ln=True)
        self.pdf.cell(0, 10, f"Laczna kwota zamowien: {total_amount:.2f} PLN", ln=True)
        self.pdf.ln(10)

    def add_order_details(self, orders):
    
        self.pdf.set_font("Arial", size=12)
        self.pdf.cell(40, 10, "Data", border=1, align="C")
        self.pdf.cell(40, 10, "Liczba pozycji", border=1, align="C")
        self.pdf.cell(40, 10, "Kwota [PLN]", border=1, align="C")
        self.pdf.ln(10)

        for order in orders:
            self.pdf.cell(40, 10, order["date"], border=1)
            self.pdf.cell(40, 10, str(order["items"]), border=1, align="C")
            self.pdf.cell(40, 10, f"{order['total']:.2f}", border=1, align="C")
            self.pdf.ln(10)

    def save_pdf(self, filename):
        """Zapisuje plik PDF."""
        self.pdf.output(filename)

    def open_pdf(self, filename):
        """Otwiera plik PDF."""
        import os, webbrowser
        if os.path.exists(filename):
            webbrowser.open_new_tab(filename)
        else:
            print(f"Blad: Plik '{filename}' nie istnieje!")


if __name__ == "__main__":
    category = "Obiad"
    total_orders = 8
    total_amount = 450.75
    orders = [
        {"date": "2025-01-01", "items": 2, "total": 50.25},
        {"date": "2025-01-03", "items": 1, "total": 30.00},
        {"date": "2025-01-10", "items": 3, "total": 90.50},
        {"date": "2025-02-01", "items": 2, "total": 45.00},
        {"date": "2025-02-15", "items": 4, "total": 120.00},
        {"date": "2025-03-05", "items": 2, "total": 50.00},
        {"date": "2025-03-10", "items": 3, "total": 65.00},
    ]

    # Generowanie raportu dla wybranej kategorii
    pdf = CategoryReportPDF("Raport Kategorii Zamowien")
    pdf.add_page()
    pdf.set_title(category)
    pdf.add_summary(total_orders, total_amount)
    pdf.add_order_details(orders)
    pdf.save_pdf("raport_kategoria_obiad.pdf")
    pdf.open_pdf("raport_kategoria_obiad.pdf")
