
from flask import Flask, Response, request, make_response
from fpdf import FPDF

from database import SQLConnection



app = Flask(__name__)

@app.route('/pdf', methods = ['GET'])
def pdf():
    
    serverName = request.args.get('server')
    databaseName = request.args.get('database')
    
    data = SQLConnection(serverName, databaseName)
    
    df = data.queryAsDataframe("select * from mealsview")
    
    
    pdf = FPDF()
    pdf.add_page()
    pdf.set_font("Arial", size=16)
    pdf.cell(200, 10, txt="Przykladowa strona PDF", ln=True, align='C')

    pdf.set_font("Arial", size=12)
    pdf.cell(200, 10, txt="To jest testowy plik PDF.", ln=True, align='C')
    
    print(df.head(10))
    
    for column in df.columns:
        pdf.cell(200, 10, txt= column, ln=True, align='C')
        pdf.cell(200, 10, txt= "Max: "+ str(df[column].max()), ln=True, align='C')
        pdf.cell(200, 10, txt= "Min: "+ str(df[column].min()), ln=True, align='C')
   
     
    headers = {
        'Content-Type': 'aplication/pdf',
        'Content-Disposition': f"attachment;filename=raport.pdf"
    }
    
   # response = Response(pdf_output, headers=headers)
    
    response = make_response((pdf.output(dest='S').encode('latin-1')))
    
    
    response.headers.set('Content-Disposition', 'attachment', filename="raport" + '.pdf')
    response.headers.set('Content-Type', 'application/pdf')
    
    return response


app.run(port=5000)
    
    
    
