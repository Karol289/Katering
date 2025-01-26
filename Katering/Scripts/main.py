
from flask import Flask, Response, request, make_response
from fpdf import FPDF

from database import SQLConnection



app = Flask(__name__)

@app.route('/pdf', methods = ['GET'])
def pdf():
    
    serverName = request.args.get('server')
    databaseName = request.args.get('database')
    
    user = request.args.get('user')
    type = request.args.get('type')
    opcje = request.args.get('opcje')
    
    
    zap = ""
    
    if user == "klient":
        if type == '1':
            zap = """select u.Name as "UserName", u.Surname, u.Email ,m.Name as "MealName", m.Price, m.MealId, o.Discount, CONVERT(DATE, o.Date) from orders o 
                    join users u on u.Id = o.UserId 
                    join MealsOrder mo on mo.OrderId = o.OrderId 
                    join Meals m on m.MealId = mo.MealId 
                    where o.OrderId = """ +str(opcje) + ";"  

        if type == "2":
            zap =  """select u.Name as "UserName", u.Surname, u.Email ,m.Name as "MealName", m.Price, m.MealId, o.Discount, CONVERT(DATE, o.Date), o.OrderId from orders o 
                    join users u on u.Id = o.UserId 
                    join MealsOrder mo on mo.OrderId = o.OrderId 
                    join Meals m on m.MealId = mo.MealId 
                    where u.Id = """ + str(opcje) + ";"
    elif (user == "mod" or user == "admin"):
        if type == '1':
            zap = """select m.Name as "MealName", m.Price, m.MealId, o.Discount, CONVERT(DATE, o.Date), o.OrderId from orders o 
                    join MealsOrder mo on mo.OrderId = o.OrderId 
                    join Meals m on m.MealId = mo.MealId"""
        if type == '2':
            zap = """SELECT mc.MealCategoryId, mc.Name as "CathegoryName", m.Name as "MealName", m.Price, mo.MealId, mo.MealOrderId
                    FROM MealCategories mc
                    join Meals m on m.MealCategoryId = mc.MealCategoryId
                    left join MealsOrder mo on m.MealId = mo.MealId
                    where mc.MealCategoryId = """ + str(opcje) + ";"
        if type == '3':
            zap = """SELECT m.MealId, m.Name as "MealName", m.Price, mo.MealOrderId, CONVERT(DATE, o.Date) as "Date"
                    from Meals m 
                    join MealsOrder mo on m.MealId = mo.MealId
                    join Orders o on o.OrderId = mo.OrderId
                    where m.MealId = """ + str(opcje) + ";"

    
    data = SQLConnection(serverName, databaseName)
    
    df = data.queryAsDataframe(zap)
    
    print(df.head(10))
    
    pdf = FPDF()
    pdf.add_page()
    pdf.set_font("Arial", size=16)
    pdf.cell(200, 10, txt="Przykladowa strona PDF", ln=True, align='C')

    pdf.set_font("Arial", size=12)
    pdf.cell(200, 10, txt="To jest testowy plik PDF.", ln=True, align='C')
    

    
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
    
    
    
