import tensorflow as tf

model_path = './saved_model.pb'
model = tf.saved_model.load(model_path)

class Model(object):
    def returnPrediction(self, bytestream):
        model.predict(bytestream)
        return prediction