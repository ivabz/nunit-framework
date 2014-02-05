#if NET_4_0 || NET_4_5
using System.Threading.Tasks;
using NUnit.Framework;
using System;

#if NET_4_0
using Task = System.Threading.Tasks.TaskEx;
#endif

namespace NUnit.TestData
{
	public class AsyncDummyFixture
	{
		[Test]
		public async void AsyncVoid()
		{
            await Task.Delay(0); // To avoid warning message
		}

		[Test]
		public async System.Threading.Tasks.Task AsyncTask()
		{
			await Task.Yield();
		}

		[Test]
		public async Task<int> AsyncGenericTask()
		{
			return await Task.FromResult(1);
		}

        [Test]
        public System.Threading.Tasks.Task NonAsyncTask()
        {
            return Task.Delay(0);
        }

        [Test]
		public Task<int> NonAsyncGenericTask()
		{
			return Task.FromResult(1);
		}

        [TestCase(4)]
        public async void AsyncVoidTestCase(int x)
        {
            await Task.Delay(0);
        }
        
        [TestCase(ExpectedResult = 1)]
        public async void AsyncVoidTestCaseWithExpectedResult()
        {
            await Task.Run(() => 1);
        }

        [TestCase(4)]
        public async System.Threading.Tasks.Task AsyncTaskTestCase(int x)
        {
            await Task.Delay(0);
        }

        [TestCase(ExpectedResult = 1)]
        public async System.Threading.Tasks.Task AsyncTaskTestCaseWithExpectedResult()
        {
            await Task.Run(() => 1);
        }

        [TestCase(4)]
        public async Task<int> AsyncGenericTaskTestCase()
        {
            return await Task.Run(() => 1);
        }

        [TestCase(ExpectedResult = 1)]
        public async Task<int> AsyncGenericTaskTestCaseWithExpectedResult()
        {
            return await Task.Run(() => 1);
        }

        [TestCase(ExpectedException = typeof(Exception))]
        public async Task<int> AsyncGenericTaskTestCaseWithExpectedException()
        {
            return await Throw();
        }

        private async Task<int> Throw()
        {
            Func<int> thrower = () => { throw new InvalidOperationException(); };
            return await Task.Run( thrower );
        }
    }
}
#endif