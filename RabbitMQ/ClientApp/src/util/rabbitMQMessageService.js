import SignalRService from '../util/signalRService';

export default class rabbitMQMessageService {
    constructor(messageReceived, mqMessageReceived) {
        this._messageReceived = messageReceived;
        this._mqMessageReceived = mqMessageReceived;

        SignalRService.registerReceiveEvent((msg) => {
            this._messageReceived(msg);
        });

        SignalRService.registerReceiveMQEvent((msg) => {
            this._mqMessageReceived(msg);
        });
    }

    sendMessage = (message) => {
        SignalRService.sendMessage(message);
    }
}