﻿namespace Akka.Monitoring.Impl
{
    /// <summary>
    /// Interface used to describe all of the reporting tools for plugging metrics to monitoring services
    /// 
    /// Akka-Monitoring can technically report to multiple reporting services at once, if necessary.
    /// </summary>
    public interface IActorPerformanceClient
    {
        /// <summary>
        /// Updates a counter by an arbitrary amount
        /// </summary>
        /// <param name="metricName">The name of the metric</param>
        /// <param name="delta">The amount to update the counter by, usually 1 or -1 but it can be arbitrary</param>
        /// <param name="sampleRate">
        /// The sample rate used for pulling readings off of the counter.
        /// 
        /// A sample rate of 0.1, for instance, would only sample 1/10 items from the counter onto the graph.
        /// 
        /// Implementation of the sample rate depends entirely on the backend being used for monitoring.
        /// </param>
        void UpdateCounter(string metricName, int delta, double sampleRate);

        /// <summary>
        /// Updates a time-based counter with the duration it took to complete an operation
        /// </summary>
        /// <param name="metricName">The name of the metric</param>
        /// <param name="time">The amount of time elasped in recording this timer</param>
        void UpdateTimer(string metricName, long time);

        /// <summary>
        /// Updates a Gauge, which is an arbitrary value that can be recorded. Might not be supported on your monitoring back-end. 
        /// </summary>
        /// <param name="metricName">The name of the metric</param>
        /// <param name="value">The amount to pass to the gauge</param>
        void UpdateGauge(string metricName, int value);
    }
}
