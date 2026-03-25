from anthropic import Anthropic

client = Anthropic()

def campaign_optimization_agent(campaign_data):
    messages = []
    while True:
        response = client.messages.create(
            model="claude-3-5-sonnet-20241022",
            max_tokens=1024,
            tools=[...],  # Define campaign tools
            messages=messages
        )
        # Handle tool_use blocks, continue dialogue