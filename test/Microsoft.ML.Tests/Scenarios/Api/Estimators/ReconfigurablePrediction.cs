﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.ML.Data;
using Microsoft.ML.RunTests;
using Microsoft.ML.Trainers;
using Xunit;

namespace Microsoft.ML.Tests.Scenarios.Api
{
    public partial class ApiScenariosTests
    {
        /// <summary>
        /// Reconfigurable predictions: The following should be possible: A user trains a binary classifier,
        /// and through the test evaluator gets a PR curve, the based on the PR curve picks a new threshold
        /// and configures the scorer (or more precisely instantiates a new scorer over the same predictor)
        /// with some threshold derived from that.
        /// </summary>
        [Fact]
        public void ReconfigurablePrediction()
        {
            var ml = new MLContext(seed: 1, conc: 1);
            var dataReader = ml.Data.ReadFromTextFile<SentimentData>(GetDataPath(TestDatasets.Sentiment.trainFilename), hasHeader: true);

            var data = ml.Data.ReadFromTextFile<SentimentData>(GetDataPath(TestDatasets.Sentiment.trainFilename), hasHeader: true);
            var testData = ml.Data.ReadFromTextFile<SentimentData>(GetDataPath(TestDatasets.Sentiment.testFilename), hasHeader: true);

            // Pipeline.
            var pipeline = ml.Transforms.Text.FeaturizeText("SentimentText", "Features")
                .Fit(data);

            var trainer = ml.BinaryClassification.Trainers.StochasticDualCoordinateAscent(
                new SdcaBinaryTrainer.Options { NumThreads = 1 });

            var trainData = ml.Data.Cache(pipeline.Transform(data)); // Cache the data right before the trainer to boost the training speed.
            var model = trainer.Fit(trainData);

            var scoredTest = model.Transform(pipeline.Transform(testData));
            var metrics = ml.BinaryClassification.Evaluate(scoredTest);

            var newModel = new BinaryPredictionTransformer<IPredictorProducing<float>>(ml, model.Model, trainData.Schema, model.FeatureColumn, threshold: 0.01f, thresholdColumn: DefaultColumnNames.Probability);
            var newScoredTest = newModel.Transform(pipeline.Transform(testData));
            var newMetrics = ml.BinaryClassification.Evaluate(scoredTest);
        }
    }
}
