import openai
openai.api_key = "......."  


while True:

    prompt = input("Pregunta: ")

    if prompt in ["exit"]:
        break

    completion = openai.ChatCompletion.create(
        model="gpt-3.5-turbo",
        messages=[{"role": "user", "content": prompt}]
        
    )
    response = completion.choices[0].message.content

    print("AI: " +response)