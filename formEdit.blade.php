<div class="form-group">
    <label class="list" for="rulingEn">@lang('dic.Ruling') @lang('dic.English') (<b style="color:red">*</b>)</label>
    <input type="text" name = "rulingEn" value="{{$ruling->RulingEn}}" class="form-control"  >
    @error('rulingEn')<p style="color:red">{{$message}}</p>@enderror

</div>
<div class="form-group">
    <label class="list" for="rulingFr">@lang('dic.Ruling') @lang('dic.French')</label>
    <input type="text" value="{{$ruling->RulingFr}}"name = "rulingFr" class="form-control"  >
    @error('rulingFr')<p style="color:red">{{$message}}</p>@enderror

</div>
<div class="form-group">
    <label class="list" for="rulingZh">@lang('dic.Ruling') @lang('dic.Chinese')</label>
    <input type="text" value="{{$ruling->RulingZh}}" name = "rulingZh" class="form-control"  >
    @error('rulingZh')<p style="color:red">{{$message}}</p>@enderror
</div>