﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace CallingMediaBot.Web.Services.CognitiveServices;

using CallingMediaBot.Web.Options;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;
using Microsoft.Extensions.Options;

public class SpeechService : ISpeechService
{
    private readonly IWebHostEnvironment environment;
    private readonly CognitiveServicesOptions cognitiveServicesOptions;

    public SpeechService(IWebHostEnvironment environment, IOptions<CognitiveServicesOptions> cognitiveServicesOptions)
    {
        this.environment = environment;
        this.cognitiveServicesOptions = cognitiveServicesOptions.Value;
    }

    public async Task<SpeechRecognitionResult> ConvertWavToText(string fileName)
    {
        if (!cognitiveServicesOptions.Enabled)
        {
            throw new Exception();
        }

        var speechConfig = SpeechConfig.FromSubscription(cognitiveServicesOptions.SpeechKey, cognitiveServicesOptions.SpeechRegion);
        speechConfig.SpeechRecognitionLanguage = cognitiveServicesOptions.SpeechRecognitionLanguage;

        var fullFilePath = Path.Combine(environment.WebRootPath, fileName);

        using var audioConfig = AudioConfig.FromWavFileInput(fullFilePath);
        using var speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

        return await speechRecognizer.RecognizeOnceAsync();
    }
}
