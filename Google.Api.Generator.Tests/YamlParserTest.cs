﻿// Copyright 2021 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Google.Api.Generator.Generation;
using Xunit;

namespace Google.Api.Generator.Tests
{
    public class YamlParserTest
    {
        [Fact]
        public void CheckDeserialization()
        {
            const string name = "dialogflow.googleapis.com";
            const string title = "Dialogflow API";
            var serviceYaml = String.Format(s, name, title);
            var syaml = ServiceYaml.ParseYaml(s);
            Assert.NotNull(syaml);
            Assert.Equal(name, syaml.Name);
            Assert.Equal(title, syaml.Title);
        }

        static string s = @"
type: google.api.Service
config_version: 3
name: {0}
title: {1}

apis:
- name: google.cloud.dialogflow.v2.Agents
- name: google.cloud.dialogflow.v2.AnswerRecords
- name: google.cloud.dialogflow.v2.Contexts
- name: google.cloud.dialogflow.v2.ConversationProfiles
- name: google.cloud.dialogflow.v2.Conversations
- name: google.cloud.dialogflow.v2.Documents
- name: google.cloud.dialogflow.v2.EntityTypes
- name: google.cloud.dialogflow.v2.Environments
- name: google.cloud.dialogflow.v2.Intents
- name: google.cloud.dialogflow.v2.KnowledgeBases
- name: google.cloud.dialogflow.v2.Participants
- name: google.cloud.dialogflow.v2.SessionEntityTypes
- name: google.cloud.dialogflow.v2.Sessions

types:
- name: google.cloud.dialogflow.v2.BatchUpdateEntityTypesResponse
- name: google.cloud.dialogflow.v2.BatchUpdateIntentsResponse
- name: google.cloud.dialogflow.v2.ConversationEvent
- name: google.cloud.dialogflow.v2.ExportAgentResponse
- name: google.cloud.dialogflow.v2.HumanAgentAssistantEvent
- name: google.cloud.dialogflow.v2.KnowledgeOperationMetadata
- name: google.cloud.dialogflow.v2.OriginalDetectIntentRequest
- name: google.cloud.dialogflow.v2.WebhookRequest
- name: google.cloud.dialogflow.v2.WebhookResponse

documentation:
  summary: |-
    Builds conversational interfaces (for example, chatbots, and voice-powered
    apps and devices).
  overview: |-
    <!-- mdformat off(presubmit failing, mdformat is as well) --> Dialogflow is
    a natural language understanding platform that makes it easy
    to design and integrate a conversational user interface into your mobile
    app, web application, device, bot, interactive voice response system, and
    so on. Using Dialogflow, you can provide new and engaging ways for
    users to interact with your product.

    Dialogflow can analyze multiple types of input from your customers,
    including text or audio inputs (like from a phone or voice recording).
    It can also respond to your customers in a couple of ways, either through
    text or with synthetic speech.

    For more information, see the
    [Dialogflow documentation](https://cloud.google.com/dialogflow/docs).

backend:
  rules:
  - selector: 'google.cloud.dialogflow.v2.Agents.*'
    deadline: 60.0
  - selector: google.cloud.dialogflow.v2.AnswerRecords.ListAnswerRecords
    deadline: 60.0
  - selector: google.cloud.dialogflow.v2.AnswerRecords.UpdateAnswerRecord
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.Contexts.*'
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.ConversationProfiles.*'
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.Conversations.*'
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.Documents.*'
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.EntityTypes.*'
    deadline: 60.0
  - selector: google.cloud.dialogflow.v2.Environments.ListEnvironments
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.Intents.*'
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.KnowledgeBases.*'
    deadline: 60.0
  - selector: 'google.cloud.dialogflow.v2.Participants.*'
    deadline: 60.0
  - selector: google.cloud.dialogflow.v2.Participants.AnalyzeContent
    deadline: 220.0
  - selector: google.cloud.dialogflow.v2.Participants.StreamingAnalyzeContent
    deadline: 220.0
  - selector: 'google.cloud.dialogflow.v2.SessionEntityTypes.*'
    deadline: 60.0
  - selector: google.cloud.dialogflow.v2.Sessions.DetectIntent
    deadline: 220.0
  - selector: google.cloud.dialogflow.v2.Sessions.StreamingDetectIntent
    deadline: 220.0
  - selector: 'google.longrunning.Operations.*'
    deadline: 60.0

http:
  rules:
  - selector: google.longrunning.Operations.CancelOperation
    post: '/v2/{{name=projects/*/operations/*}}:cancel'
    additional_bindings:
    - post: '/v2/{{name=projects/*/locations/*/operations/*}}:cancel'
  - selector: google.longrunning.Operations.GetOperation
    get: '/v2/{{name=projects/*/operations/*}}'
    additional_bindings:
    - get: '/v2/{{name=projects/*/locations/*/operations/*}}'
  - selector: google.longrunning.Operations.ListOperations
    get: '/v2/{{name=projects/*}}/operations'
    additional_bindings:
    - get: '/v2/{{name=projects/*/locations/*}}/operations'

authentication:
  rules:
  - selector: 'google.cloud.dialogflow.v2.Agents.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: google.cloud.dialogflow.v2.AnswerRecords.ListAnswerRecords
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: google.cloud.dialogflow.v2.AnswerRecords.UpdateAnswerRecord
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.Contexts.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.ConversationProfiles.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.Conversations.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.Documents.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.EntityTypes.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: google.cloud.dialogflow.v2.Environments.ListEnvironments
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.Intents.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.KnowledgeBases.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.Participants.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.cloud.dialogflow.v2.SessionEntityTypes.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: google.cloud.dialogflow.v2.Sessions.DetectIntent
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: google.cloud.dialogflow.v2.Sessions.StreamingDetectIntent
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
  - selector: 'google.longrunning.Operations.*'
    oauth:
      canonical_scopes: |-
        https://www.googleapis.com/auth/cloud-platform,
        https://www.googleapis.com/auth/dialogflow
";
    }
}
