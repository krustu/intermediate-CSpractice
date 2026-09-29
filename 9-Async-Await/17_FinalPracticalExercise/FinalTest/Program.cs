using System;
class Program
{
    static async Task Main()
    {
        using var cts = new CancellationTokenSource();

        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };
        List<RequestResult> errors = new();
        List<RequestResult> success = new();

        try
        {
            while (!cts.Token.IsCancellationRequested)
            {
                var Tasks = new List<Task<RequestResult>>()
                {
            Request1(cts.Token),
            Request2(cts.Token),
            Request3(cts.Token),

                };

                var answerobj = await Task.WhenAll(Tasks);

                foreach (var result in answerobj)
                {
                    if (result.Error != null)
                        errors.Add(result);
                    else
                    {
                        success.Add(result);
                    }
                }
                await Task.Delay(2000, cts.Token);



            }


        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Program closing...");
            Console.WriteLine($"Errors count - {errors.Count}");
            Console.WriteLine($"Success count - {success.Count}");

        }


    }
    static async Task<RequestResult> Request1(CancellationToken Token)
    {
        try
        {
            if (Random.Shared.Next(0, 7) == 0)
            {
                throw new Exception("Request 1 - Failed!");
            }
            await Task.Delay(1000, Token);
            return new RequestResult
            {
                Value = "Request 1 - Success"
            };
        }


        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new RequestResult
            {
                Error = ex
            };
        }
        finally
        {
            Console.WriteLine("Request 1 - completed");
        }

    }
    static async Task<RequestResult> Request2(CancellationToken Token)
    {
        try
        {
            if (Random.Shared.Next(0, 4) == 0)
            {
                throw new Exception("Request 2 - Failed!");
            }

            await Task.Delay(2000, Token);
            return new RequestResult
            {
                Value = "Request 2 - Success"
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new RequestResult
            {
                Error = ex
            };
        }
        finally
        {
            Console.WriteLine("Request 2 - completed");
        }

    }
    static async Task<RequestResult> Request3(CancellationToken Token)
    {
        try
        {
            if (Random.Shared.Next(0, 6) == 0)
            {
                throw new Exception("Request 3 - Failed!");
            }
            await Task.Delay(3000, Token);
            return new RequestResult
            {
                Value = "Request 3 - Success"
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new RequestResult
            {
                Error = ex
            };
        }
        finally
        {
            Console.WriteLine("Request 3 - completed");
        }

    }
}
class RequestResult
{
    public string? Value { get; set; }
    public Exception? Error { get; set; }
}