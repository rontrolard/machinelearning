﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.ML.Data;
using Microsoft.ML.LightGBM;

namespace Microsoft.ML
{
    /// <summary>
    /// LightGBM extension methods.
    /// </summary>
    public static class LightGbmExtensions
    {
        /// <summary>
        /// Predict a target using a decision tree regression model trained with the <see cref="LightGbmRegressorTrainer"/>.
        /// </summary>
        /// <param name="ctx">The <see cref="RegressionContext"/>.</param>
        /// <param name="labelColumn">The label column.</param>
        /// <param name="featureColumn">The features column.</param>
        /// <param name="weights">The weights column.</param>
        /// <param name="numLeaves">The number of leaves to use.</param>
        /// <param name="numBoostRound">Number of iterations.</param>
        /// <param name="minDataPerLeaf">The minimal number of documents allowed in a leaf of the tree, out of the subsampled data.</param>
        /// <param name="learningRate">The learning rate.</param>
        /// <param name="advancedSettings">A delegate to set more settings.
        /// The settings here will override the ones provided in the direct signature,
        /// if both are present and have different values.
        /// The columns names, however need to be provided directly, not through the <paramref name="advancedSettings"/>.</param>
        public static LightGbmRegressorTrainer LightGbm(this RegressionContext.RegressionTrainers ctx,
            string labelColumn = DefaultColumnNames.Label,
            string featureColumn = DefaultColumnNames.Features,
            string weights = null,
            int? numLeaves = null,
            int? minDataPerLeaf = null,
            double? learningRate = null,
            int numBoostRound = LightGbmArguments.Defaults.NumBoostRound,
            Action<LightGbmArguments> advancedSettings = null)
        {
            Contracts.CheckValue(ctx, nameof(ctx));
            var env = CatalogUtils.GetEnvironment(ctx);
            return new LightGbmRegressorTrainer(env, labelColumn, featureColumn, weights, numLeaves, minDataPerLeaf, learningRate, numBoostRound, advancedSettings);
        }

        /// <summary>
        /// Predict a target using a decision tree binary classification model trained with the <see cref="LightGbmBinaryTrainer"/>.
        /// </summary>
        /// <param name="ctx">The <see cref="BinaryClassificationContext"/>.</param>
        /// <param name="labelColumn">The label column.</param>
        /// <param name="featureColumn">The features column.</param>
        /// <param name="weights">The weights column.</param>
        /// <param name="numLeaves">The number of leaves to use.</param>
        /// <param name="numBoostRound">Number of iterations.</param>
        /// <param name="minDataPerLeaf">The minimal number of documents allowed in a leaf of the tree, out of the subsampled data.</param>
        /// <param name="learningRate">The learning rate.</param>
        /// <param name="advancedSettings">A delegate to set more settings.
        /// The settings here will override the ones provided in the direct signature,
        /// if both are present and have different values.
        /// The columns names, however need to be provided directly, not through the <paramref name="advancedSettings"/>.</param>
        public static LightGbmBinaryTrainer LightGbm(this BinaryClassificationContext.BinaryClassificationTrainers ctx,
            string labelColumn = DefaultColumnNames.Label,
            string featureColumn = DefaultColumnNames.Features,
            string weights = null,
            int? numLeaves = null,
            int? minDataPerLeaf = null,
            double? learningRate = null,
            int numBoostRound = LightGbmArguments.Defaults.NumBoostRound,
            Action<LightGbmArguments> advancedSettings = null)
        {
            Contracts.CheckValue(ctx, nameof(ctx));
            var env = CatalogUtils.GetEnvironment(ctx);
            return new LightGbmBinaryTrainer(env, labelColumn, featureColumn, weights, numLeaves, minDataPerLeaf, learningRate, numBoostRound, advancedSettings);

        }

        /// <summary>
        /// Predict a target using a decision tree binary classification model trained with the <see cref="LightGbmRankingTrainer"/>.
        /// </summary>
        /// <param name="ctx">The <see cref="RankingContext"/>.</param>
        /// <param name="labelColumn">The label column.</param>
        /// <param name="featureColumn">The features column.</param>
        /// <param name="weights">The weights column.</param>
        /// <param name="groupIdColumn">The groupId column.</param>
        /// <param name="numLeaves">The number of leaves to use.</param>
        /// <param name="numBoostRound">Number of iterations.</param>
        /// <param name="minDataPerLeaf">The minimal number of documents allowed in a leaf of the tree, out of the subsampled data.</param>
        /// <param name="learningRate">The learning rate.</param>
        /// <param name="advancedSettings">A delegate to set more settings.
        /// The settings here will override the ones provided in the direct signature,
        /// if both are present and have different values.
        /// The columns names, however need to be provided directly, not through the <paramref name="advancedSettings"/>.</param>
        public static LightGbmRankingTrainer LightGbm(this RankingContext.RankingTrainers ctx,
            string labelColumn = DefaultColumnNames.Label,
            string featureColumn = DefaultColumnNames.Features,
            string groupIdColumn = DefaultColumnNames.GroupId,
            string weights = null,
            int? numLeaves = null,
            int? minDataPerLeaf = null,
            double? learningRate = null,
            int numBoostRound = LightGbmArguments.Defaults.NumBoostRound,
            Action<LightGbmArguments> advancedSettings = null)
        {
            Contracts.CheckValue(ctx, nameof(ctx));
            var env = CatalogUtils.GetEnvironment(ctx);
            return new LightGbmRankingTrainer(env, labelColumn, featureColumn, groupIdColumn, weights, numLeaves, minDataPerLeaf, learningRate, numBoostRound, advancedSettings);

        }

        /// <summary>
        /// Predict a target using a decision tree binary classification model trained with the <see cref="LightGbmRankingTrainer"/>.
        /// </summary>
        /// <param name="ctx">The <see cref="RankingContext"/>.</param>
        /// <param name="labelColumn">The label column.</param>
        /// <param name="featureColumn">The features column.</param>
        /// <param name="weights">The weights column.</param>
        /// <param name="numLeaves">The number of leaves to use.</param>
        /// <param name="numBoostRound">Number of iterations.</param>
        /// <param name="minDataPerLeaf">The minimal number of documents allowed in a leaf of the tree, out of the subsampled data.</param>
        /// <param name="learningRate">The learning rate.</param>
        /// <param name="advancedSettings">A delegate to set more settings.
        /// The settings here will override the ones provided in the direct signature,
        /// if both are present and have different values.
        /// The columns names, however need to be provided directly, not through the <paramref name="advancedSettings"/>.</param>
        public static LightGbmMulticlassTrainer LightGbm(this MulticlassClassificationContext.MulticlassClassificationTrainers ctx,
            string labelColumn = DefaultColumnNames.Label,
            string featureColumn = DefaultColumnNames.Features,
            string weights = null,
            int? numLeaves = null,
            int? minDataPerLeaf = null,
            double? learningRate = null,
            int numBoostRound = LightGbmArguments.Defaults.NumBoostRound,
            Action<LightGbmArguments> advancedSettings = null)
        {
            Contracts.CheckValue(ctx, nameof(ctx));
            var env = CatalogUtils.GetEnvironment(ctx);
            return new LightGbmMulticlassTrainer(env, labelColumn, featureColumn, weights, numLeaves, minDataPerLeaf, learningRate, numBoostRound, advancedSettings);

        }
    }
}
