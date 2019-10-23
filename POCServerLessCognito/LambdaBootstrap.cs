using System;

namespace POCServerLessCognito
{
    internal class LambdaBootstrap : IDisposable
    {
        private object handlerWrapper;

        public LambdaBootstrap(object handlerWrapper)
        {
            this.handlerWrapper = handlerWrapper;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}