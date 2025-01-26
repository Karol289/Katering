from fpdf import FPDF


class SummaryPDFReport:


    def __init__(self, title="Raport Podsumowujący Zamowienia"):
        self.pdf = FPDF()
        self.title = title

    def add_page(self):
        self.pdf.add_page()

    def set_title(self):
        self.pdf.set_font("Arial", size=16, style="B")
        self.pdf.cell(0, 10, self.title, ln=True, align="C")
        self.pdf.ln(10)

    def add_client_info(self, client_name, client_id):
        self.pdf.set_font("Arial", size=12)
        self.pdf.cell(0, 10, f"Klient: {client_name}", ln=True)
        self.pdf.cell(0, 10, f"ID klienta: {client_id}", ln=True)
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
        self.pdf.output(filename)

    def open_pdf(self, filename):
        import os, webbrowser
        if os.path.exists(filename):
            webbrowser.open_new_tab(filename)
        else:
            print(f"Blad: Plik '{filename}' nie istnieje!")


if __name__ == "__main__":
    # Dane przykładowe
    client_name = "Jan Kowalski"
    client_id = "123456"
    total_orders = 12
    total_amount = 1250.50
    orders = [
        {"date": "2025-01-01", "items": 3, "total": 150.00},
        {"date": "2025-01-15", "items": 5, "total": 250.50},
        {"date": "2025-02-10", "items": 2, "total": 100.00},
        {"date": "2025-02-20", "items": 4, "total": 180.00},
        {"date": "2025-03-05", "items": 6, "total": 570.00},
    ]

    # Generowanie raportu
    pdf = SummaryPDFReport("Roczny Raport Zamowien")
    pdf.add_page()
    pdf.set_title()
    pdf.add_client_info(client_name, client_id)
    pdf.add_summary(total_orders, total_amount)
    pdf.add_order_details(orders)
    pdf.save_pdf("roczny_raport_zamowien.pdf")
    pdf.open_pdf("roczny_raport_zamowien.pdf")
