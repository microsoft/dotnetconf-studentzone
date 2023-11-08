# Student Copilot

This application uses AI to process transcripts from video lectures along with lesson notes. These are then used to help users chat with their data and study more efficiently. 

## Data Sources

| Item | Transcript | Lesson |
| --- | --- | --- |
| 01 Introduction | https://youtu.be/6mSx_KJxcHI?si=vpnq5Vt7_0L-LOGK | https://github.com/microsoft/ML-For-Beginners/blob/main/1-Introduction/1-intro-to-ML/README.md |
| 02 - History of Machine Learning | https://youtu.be/N6wxM4wZ7V0?si=ozi2V4rQWMtKDOWx | https://github.com/microsoft/ML-For-Beginners/tree/main/1-Introduction/2-history-of-ML |
| 03 - Techniques for Machine Learning | https://youtu.be/4NGM0U2ZSHU?si=KDZPhL44UGiN8qsl | https://youtu.be/4NGM0U2ZSHU?si=CU1AHOUt_JErYUqX | https://github.com/microsoft/ML-For-Beginners/blob/main/1-Introduction/4-techniques-of-ML/README.md |

## Prerequisites

- [Azure Account](https://aka.ms/free)
- [Azure OpenAI Service](https://learn.microsoft.com/azure/ai-services/openai/faq#how-do-i-get-access-to-azure-openai--)
  - [Model deployments](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource?pivots=web-portal#deploy-a-model)
    - [gpt-35-turbo-16k](https://learn.microsoft.com/azure/ai-services/openai/concepts/models#gpt-35)
    - [text-embedding-ada-002](https://learn.microsoft.com/azure/ai-services/openai/how-to/create-resource?pivots=web-portal#deploy-a-model)

## Project Setup

You can run this project using GitHub Codespaces or configuring all the prerequisites locally on your PC.

## Codespaces

The quickest way for you to get started is using GitHub Codespaces. Click the button below to open this project in GitHub Codespaces.

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/luisquintanilla/dotnet-student-zone-2023)

### Local setup

When running the project locally, you'll have to install additional prerequisites.

#### Additional prerequisites

- [Visual Studio Code](https://code.visualstudio.com/Download)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://docs.docker.com/get-docker/)

> **Important**<br>
> Ensure Docker is running before running any `docker` commands.

## Quick Start

1. Open project in [GitHub Codespaces](#codespaces).
1. Open [.devcontainer/devcontainer.json](.devcontainer/devcontainer.json) and update the environment variables under the `containerEnv` property.

    - **AZURE_OPENAI_CHAT_DEPLOYMENT**: The name of your gpt-35-turbo-16k deployment. 
    - **AZURE_OPENAI_EMBEDDING_DEPLOYMENT**: The name of your text-embedding-ada-002 deployment. 
	- **AZURE_OPENAI_ENDPOINT**: The endpoint for your Azure OpenAI resource. 
    - **AZURE_OPENAI_KEY**: The key for your Azure OpenAI resource.
	- **QDRANT_HOST**: The hostname and port where your Qdrant vector store is hosted. (i.e. *http://localhost:6333*)

1. Rebuild container.

    1. Open the command palette. In the menu bar, select **View > Command Palette**.
    1. Enter the following command into the command palette **>Codespaces: Rebuild Container**.

1. Start vector store

    ```bash
    docker run -p 6333:6333 qdrant/qdrant
    ```

    Alternatively, if you'd like to deploy an instance to Azure, you can use this [guide](https://github.com/Azure-Samples/qdrant-azure).

1. Open [Data-Prep.ipynb](./Data-Prep.ipynb) notebook and run it. This notebook takes the data from transcripts and lesson notes, generates embeddings, and stores them in the vector store.
1. Once your data is in the vector store, you can chat with it using the `ChatML.Console` application.
    1. Navigate to the *src/ChatML.Console* directory.
    1. Run the application

        ```bash
        dotnet run 
        ``` 

        Once the application starts, you can begin chatting with your data. 

## Solution Overview 

### Azure OpenAI Service

[Azure OpenAI Service](https://learn.microsoft.com/azure/ai-services/openai/overview) provides access to the text embedding and large language models used in this application.  

### Semantic Kernel

We use [Semantic Kernel](https://github.com/microsoft/semantic-kernel) to compose the different AI components in the application.

### Qdrant

The vectore store used in this project for text embeddings is [Qdrant](https://qdrant.tech/) 

## ChatML.Console

```bash

Run ChatML.Console , you can ask some ML and AI question to OpenAI , like this 

Welcoment to ChatML Console! I am your ML assistant. Please ask me any question about ML and AI.
Ask: do you know what history of AI

Bot: Machine learning and artificial intelligence (AI) have a rich history that dates back centuries. The development of AI is closely tied to advancements in machine learning algorithms and computational techniques. Notable discoveries include Bayes Theorem in 1763, Least Square Theory in 1805, Markov Chains in 1913, the Perceptron in 1957, Nearest Neighbor algorithm in 1967, Backpropagation in 1970, and Recurrent Neural Networks in 1982. 

In 1950, Alan Turing laid the foundation for the concept of a "thinking machine" and created the Turing Test to explore this idea. The Dartmouth Summer Research Project in 1956 marked the birth of the term "artificial intelligence." From the 1950s to the mid-1970s, there was great optimism about AI's potential. However, the complexity of creating intelligent machines became apparent, leading to an "AI Winter" from 1974 to 1980, where funding and confidence in the field declined.

In the 1980s, expert systems emerged as successful AI software, combining rules engines and inference engines. The proliferation of specialized hardware and the rise of personal computers led to an "AI Chill" from 1987 to 1993. However, from 1993 to 2011, ML and AI entered a new era with the availability of more data and increased computing power. The field matured, and today, ML and AI are pervasive in our lives. It is crucial to understand the risks and effects of these algorithms, and this curriculum aims to provide that understanding.
Ask: do you know what is different between AI and Ml
Bot: going to focus on machine learning and its relationship to artificial intelligence. Machine learning is a branch of AI that uses algorithms to make decisions by learning from data. It is a popular and successful approach in AI. Deep learning, on the other hand, is a subset of machine learning that relies on neural networks to learn from data. In this course, we will primarily explore machine learning and its connection to artificial intelligence.

```


## Speaker(s)

[**Luis Quintanilla**](https://www.lqdev.me/hi) - Luis is a Program Manager at Microsoft who's passionate about helping others get started building AI solutions in .NET.

[**Kinfey Lo**](https://github.com/kinfey)** - Kinfey Lo is Microsoft Senior Cloud Advoate, focus on artificial intelligence and big data applications.