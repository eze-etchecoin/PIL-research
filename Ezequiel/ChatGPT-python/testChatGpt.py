import openai

API_KEY = "....."

openai.api_key

print("GPT-3.5-turbo Test")

while(True):
    
    print("Ask for something...\n")
    prompt = input()

    if prompt.lower() == "exit":
        break

print("Adiós...")
