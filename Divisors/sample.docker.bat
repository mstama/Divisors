@REM CREATE AND RUN THE DOCKER IMAGE SAMPLE
docker build . -f sample.dockerfile -t sample.divisors
docker run sample.divisors