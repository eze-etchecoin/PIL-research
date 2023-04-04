import openai

openai.api_key = "........"

while True:

    model = "text-davinci-003"

    prompt = input("Pregunta: ")

    if prompt in ["exit"]:
        break

    completion = openai.Completion.create(
        engine=model,
        prompt=prompt,
        max_tokens=1024,
        n=1,
        stop=None,
        temperature=0.3
    )
    response = completion.choices[0].text

    print("AI: " +response)